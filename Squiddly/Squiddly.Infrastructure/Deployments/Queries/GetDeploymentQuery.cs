namespace Squiddly.Infrastructure.Deployments.Queries
{
    using MediatR;

    public class GetDeploymentQuery : DeploymentQueryDto, IRequest<DeploymentResult>
    {
    }
}