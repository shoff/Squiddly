namespace Squiddly.Dtos.Issues
{
    public class IssueDto
    {
        public long IssueId { get; set; }
        public string StackTrace { get; set; }
        public long DeploymentId { get; set; }
    }
}