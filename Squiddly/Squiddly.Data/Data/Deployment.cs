
using System.ComponentModel.DataAnnotations;

namespace Squiddly.Data.Data
{
    public class Deployment
    {
        [Key]
        public int DeploymentId { get; set; }

        public string DeploymentName { get; set; }
    }
}
