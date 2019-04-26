namespace Squiddly.Data.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Issue
    {
        [Key]
        public long IssueId { get; set; }

        [StringLength(2048)]
        public string StackTrace { get; set; }
        [ForeignKey("Deployment")]
        public long DeploymentId { get; set; }
        public virtual Deployment Deployment { get; set; }
    }
}