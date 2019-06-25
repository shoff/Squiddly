namespace Squiddly.Messages.Deployments
{
    using System.ComponentModel.DataAnnotations;

    public class GetDeploymentMessage
    {
        public long DeploymentId { get; set; }
        [StringLength(256)]
        public string DeploymentName { get; set; }
    }
}