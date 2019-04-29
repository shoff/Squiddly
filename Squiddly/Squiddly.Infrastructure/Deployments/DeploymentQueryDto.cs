namespace Squiddly.Infrastructure.Deployments
{
    using System.ComponentModel.DataAnnotations;

    public class DeploymentQueryDto
    {
        public long DeploymentId { get; set; }
        [StringLength(256)]
        public string DeploymentName { get; set; }
    }
}