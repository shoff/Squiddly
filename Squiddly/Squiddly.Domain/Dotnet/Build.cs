namespace Squiddly.Domain.Dotnet
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using ChaosMonkey.Guards;
    using Microsoft.Extensions.Logging;

    public class Build : BaseCmd
    {

        public Build(ILogger<Build> logger, IProgressFactory progressFactory)
            : base(logger, progressFactory.Build())
        { 
        }

        public override string Command { get; protected set; } = "build";

        public override void Execute(string workingDirectory)
        {
            Guard.IsNotNullOrWhitespace(workingDirectory, nameof(workingDirectory));
            if (!Directory.Exists(workingDirectory))
            {
                throw new ApplicationException($"{workingDirectory} does not exist.");
            }

            this.processStartInfo.WorkingDirectory = workingDirectory;
            this.processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.processStartInfo.CreateNoWindow = true;
            this.processStartInfo.RedirectStandardOutput = true;
            this.processStartInfo.UseShellExecute = false;
            this.processStartInfo.RedirectStandardInput = true;
            this.processStartInfo.Arguments = this.BuildArguments(workingDirectory);

            this.process = Process.Start(this.processStartInfo);
            this.process.OutputDataReceived += this.OnOutputDataReceived;
            this.process.BeginOutputReadLine();

            // do not reverse order of synchronous read to end and WaitForExit or deadlock
            // Wait for the process to end.  
            this.process.WaitForExit();
        }

        public bool Interactive { get; set; } = false;
        public bool NoIncremental { get; set; }
        public bool NoLogo { get; set; }
        public bool NoRestore { get; set; }
    }
}