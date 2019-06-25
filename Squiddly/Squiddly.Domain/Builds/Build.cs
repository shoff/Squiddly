namespace Squiddly.Domain.Builds
{
    using System.Collections.Generic;

    public class Build
    {
        public ICollection<BuildStep> Steps { get; set; } = new HashSet<BuildStep>();

        internal void RemoveBuildStep(string name)
        {
            throw new System.NotImplementedException();
        }

        internal void AddBuildStep(BuildStep buildStep)
        {
            throw new System.NotImplementedException();
        }
    }
}