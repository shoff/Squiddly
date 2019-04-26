namespace Squiddly.Domain.Squirts
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using ChaosMonkey.Guards;
    using FluentFTP;
    using Polly;

    public class FtpSquirt : FtpClient, ISquirtable
    {
        private int totalRequests;
        private int eventualSuccesses;


        public FtpSquirt() { }

        public FtpSquirt(string host, string username, string password)
            : base(host, username, password)
        {
            this.DataConnectionType = FtpDataConnectionType.EPSV;
            this.SetWorkingDirectory("/");

        }

        public async Task UploadFolderAsync(string folder, string remoteFolder, CancellationToken cancellationToken, IProgress<UploadProgress> progress)
        {
            Guard.IsNotNullOrWhitespace(folder, nameof(folder));
            Guard.IsNotDefault(cancellationToken, nameof(cancellationToken));
            Guard.IsNotNull(progress, nameof(progress));

            var uploadProgress = new UploadProgress("upload starting", 0, 1);
            eventualSuccesses = 0;
            progress.Report(uploadProgress);

            // Define our policy:
            var policy = Policy.Handle<FileNotFoundException>().WaitAndRetryAsync(
                retryCount: 3, // Retry 3 times
                sleepDurationProvider: attempt => TimeSpan.FromMilliseconds(200), // Wait 200ms between each try.
                onRetry: (exception, calculatedWaitDuration) => // Capture some info for logging!
                {
                    // This is your new exception handler! 
                    // Tell the user what they've won!
                    var ie = exception.InnerException;
                    var message = "An error has occured sending the file to the sever. ";
                    if (ie != null)
                    {
                        message += ie.Message;
                    }
                    progress.Report(new UploadProgress(message + exception.Message, exception: true));
                });

            totalRequests = 0;
            bool internalCancel = false;

            // Do the following until a key is pressed
            while (!internalCancel && !cancellationToken.IsCancellationRequested)
            {
                var fileList = Directory.GetFiles(folder);
                for (int i = 0; i < fileList.Length; i++)
                {
                    totalRequests++;

                    try
                    {
                        // Retry the following call according to the policy - 3 times.
                        await policy.ExecuteAsync(async token =>
                        {
                            using (var ms = new MemoryStream(File.ReadAllBytes(fileList[i])))
                            {
                                var remoteFile = fileList[i].Substring(fileList[i].LastIndexOf('\\') + 1);
                                bool result = await this.UploadAsync(ms, $"/{remoteFile}", token: token);
                                progress.Report(new UploadProgress(remoteFile, i, fileList.Length));
                            }
                        }, cancellationToken);
                    }
                    catch (Exception e)
                    {
                        progress.Report(new UploadProgress("Request " + totalRequests + " eventually failed with: " + e.Message, exception: true));
                        throw;
                    }

                    // Wait half second
                    await Task.Delay(TimeSpan.FromSeconds(0.5), cancellationToken);
                }
                internalCancel = true;
            }

        }

    }

    public class UploadProgress
    {
        public UploadProgress(string message, int complete = 0, int total = 0, bool exception = false)
        {
            if (!exception)
            {
                var percent = (double) 100.0 * (double) complete / (double) total;
                Message = $"Uploaded {message} {complete} of {total} - ({(int)percent} %) completed";
            }
            else
            {
                Message = message;
            }
        }
        public string Message { get; set; }
    }
}
