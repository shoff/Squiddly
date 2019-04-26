using Squiddly.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Squiddly
{
    using Domain.Squirts;

    class Program
    {
        static async Task Main(string[] args)
        {
            // first arg is squirt to use
            FtpSquirt squirt = new FtpSquirt(args[1], args[2], args[3]);
            // squirt.Connect(args[1], args[2], args[3]);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            IProgress<UploadProgress> progress = new Progress<UploadProgress>(pr=> Console.WriteLine(pr.Message));
            await squirt.UploadFolderAsync(args[4], args.Length > 5 ? args[5] : "/", cancellationTokenSource.Token, progress);
        }
    }
}
