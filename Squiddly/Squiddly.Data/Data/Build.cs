namespace Squiddly.Data.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Build
    {
        [Key]
        public int BuildId { get; set; }

        public ICollection<BuildStep> BuildSteps { get; set; } = new HashSet<BuildStep>();

    }

    public class BuildStep
    {
        [Key]
        public int BuildStepId { get; set; }

        public string SquirtName { get; set; }
    }
}