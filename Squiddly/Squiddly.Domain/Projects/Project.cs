namespace Squiddly.Domain.Projects
{
    using System;
    using Builds;

    public class Project
    {
        public Build Build { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public DateTime? LastRun { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string Repository { get; set; }
        public void RemoveBuildStep(string name)
        {
            this.Build.RemoveBuildStep(name);
        }

        public void AddBuildStep(BuildStep buildStep)
        {
            this.Build.AddBuildStep(buildStep);
        }
    }
}