namespace Squiddly.Domain.Dotnet.Squirts
{
    using System;
    using System.Collections.Generic;

    // TODO validate that this i a decent way to do this...
    public static class SquirtBuilder
    {

        private static readonly IDictionary<CLI, Func<DotnetSquirt>> strategies = new Dictionary<CLI, Func<DotnetSquirt>>
        {
            { CLI.Build, CreateBuildCommand },
            { CLI.Nuget, CreateNugetCommand },
            { CLI.Publish, CreatePublishCommand },
            { CLI.Restore, CreateRestoreCommand },
            { CLI.Test, CreateTestCommand }
        };

        public static DotnetSquirt BuildSquirt(CLI command)
        {
            return strategies[command].Invoke();
        }

        private static DotnetSquirt CreateTestCommand()
        {
            return new TestSquirt();
        }

        private static DotnetSquirt CreateRestoreCommand()
        {
            return new RestoreSquirt();
        }

        private static DotnetSquirt CreatePublishCommand()
        {
            return new PublishSquirt();
        }

        private static DotnetSquirt CreateNugetCommand()
        {
            return new NugetSquirt();
        }

        private static DotnetSquirt CreateBuildCommand()
        {
            return new BuildSquirt();
        }
    }
}