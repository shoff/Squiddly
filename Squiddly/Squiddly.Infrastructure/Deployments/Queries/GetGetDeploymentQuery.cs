namespace Squiddly.Infrastructure.Deployments.Queries
{
    using MediatR;
    using Messages.Deployments;

    public class GetGetDeploymentQuery : GetDeploymentMessage, IRequest<DeploymentResult>
    {
    }
}