using ChaosMonkey.Guards;
using FluentFTP;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Squiddly.Domain
{
    public class FtpSquirt : FtpClient, ISquirtable
    {
        private int totalRequests;
        private int eventualSuccesses;
        private int retries;
        private int eventualFailures;
        private string host;
        private string username;
        private string password;


        public FtpSquirt() { }

        public FtpSquirt(string host, string username, string password)
            : base(host, username, password)
        {
            this.host = host;
            this.username = username;
            this.password = password;
            this.Host = host;
            this.Credentials = new NetworkCredential(username, password);
            this.Connect(host, username, password);
        }

        public new void Connect(string host, string username, string password)
        {
            if (!this.IsConnected)
            {
                this.Host = host;
                this.Credentials = new NetworkCredential(username, password);
                this.Connect(host, username, password);
                this.DataConnectionType = FtpDataConnectionType.EPSV;
                base.Connect();
                this.SetWorkingDirectory("/");
            }
        }

        public async Task UploadFolderAsync(string folder, string remoteFolder, CancellationToken cancellationToken, IProgress<UploadProgress> progress)
        {
            Guard.IsNotNullOrWhitespace(folder, nameof(folder));
            Guard.IsNotDefault(cancellationToken, nameof(cancellationToken));
            Guard.IsNotNull(progress, nameof(progress));

            var uploadProgress = new UploadProgress("upload starting");
            eventualSuccesses = 0;
            retries = 0;
            eventualFailures = 0;

            var listing = await this.GetListingAsync(cancellationToken);
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
                    progress.Report(uploadProgress.AddMessage(message + exception.Message));
                    retries++;
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
                            }
                        }, cancellationToken);
                    }
                    catch (Exception e)
                    {
                        progress.Report(uploadProgress.AddMessage("Request " + totalRequests + " eventually failed with: " + e.Message));
                        eventualFailures++;
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
        public UploadProgress(string message)
        {
            Messages.Add(message);
        }

        public UploadProgress AddMessage(string message)
        {
            this.Messages.Add(message);
            return this;
        }
        public ICollection<string> Messages => new List<string>();
    }
}
