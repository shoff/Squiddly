
using System.ComponentModel.DataAnnotations;

namespace Squiddly.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    
    public class Deployment
    {
        [Key]
        public long DeploymentId { get; set; }

        // passed by system.teamcity.projectName
        [StringLength(256)]
        public string DeploymentName { get; set; }
        public string Project { get; set; }
        
        public DateTime Started { get; set; }
        public DateTime Completed { get; set; }
        public virtual ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();

    }
}
