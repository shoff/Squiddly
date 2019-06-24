namespace Squiddly.Domain.Dotnet
{
    using System;

    public interface IProgressFactory
    {
        IProgress<CmdProgress> Build();
    }
}