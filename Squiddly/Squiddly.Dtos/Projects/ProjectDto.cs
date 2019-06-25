namespace Squiddly.Dtos.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectDto
    {
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastRun { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Repository { get; set; }
        public ICollection<string> Branches { get; set; } = new HashSet<string>();
    }
}