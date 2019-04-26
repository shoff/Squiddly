namespace Squiddly.Infrastructure.Deployments
{
    using System;
    using System.Collections.Generic;
    using Issues;

    public class DeploymentDto
    {
        public long DeploymentId { get; set; }
        public string DeploymentName { get; set; }
        public DateTime Started { get; set; }
        public DateTime Completed { get; set; }
        public ICollection<IssueDto> Issues { get; set; } = new HashSet<IssueDto>();

    }
}