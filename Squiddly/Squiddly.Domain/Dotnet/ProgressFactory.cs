namespace Squiddly.Domain.Dotnet
{
    using System;

    public class ProgressFactory : IProgressFactory
    {
        public IProgress<CmdProgress> Build()
        {
            return new Progress<CmdProgress>();
        }
    }
}