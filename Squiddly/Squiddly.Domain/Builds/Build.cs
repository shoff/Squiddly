namespace Squiddly.Domain.Builds
{
    using System.Collections.Generic;

    public class Build
    {
        public ICollection<IBuildStep> Steps { get; set; } = new HashSet<IBuildStep>();

        internal void RemoveBuildStep(string name)
        {
            throw new System.NotImplementedException();
        }

        internal void AddBuildStep(IBuildStep buildStep)
        {
            throw new System.NotImplementedException();
        }
    }
}