using Squiddly.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Squiddly
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // first arg is squirt to use
            FtpSquirt squirt = (FtpSquirt)SquirtParser.GetSquirt(args);
            squirt.Connect(args[1], args[2], args[3]);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            IProgress<UploadProgress> progress = new Progress<UploadProgress>();
            await squirt.UploadFolderAsync(args[4], args.Length > 4 ? args[5] : "/", cancellationTokenSource.Token, progress);
        }
    }
}
