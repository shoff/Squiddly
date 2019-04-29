namespace Squiddly.Domain.Deployments.Queries
{
    using Infrastructure.Deployments;
    using MediatR;

    public class GetDeploymentQuery : DeploymentQueryDto, IRequest<DeploymentResult>
    {
    }
}