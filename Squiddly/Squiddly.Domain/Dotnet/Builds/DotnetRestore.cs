namespace Squiddly.Domain.Dotnet.Builds
{
    public class DotnetRestore : DotnetBuildStep
    {
        public DotnetRestore()
        {
            this.name = "Restore";
        }
    }
}