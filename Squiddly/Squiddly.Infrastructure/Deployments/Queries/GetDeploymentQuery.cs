namespace Squiddly.Infrastructure.Deployments.Queries
{
    using Dtos.Deployments;
    using MediatR;

    public class GetDeploymentQuery : DeploymentQueryDto, IRequest<DeploymentResult>
    {
    }
}