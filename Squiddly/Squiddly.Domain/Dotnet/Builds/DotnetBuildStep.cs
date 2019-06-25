namespace Squiddly.Domain.Dotnet.Builds
{
    using Domain.Builds;

    public abstract class DotnetBuildStep : IBuildStep
    {
        protected string name;

        // setter to make newtonsoft happy
        public string Name { get; private set; } 
    }
}