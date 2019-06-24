namespace Squiddly.Infrastructure.Deployments.Commands
{
    using Dtos.Deployments;
    using MediatR;

    public class CreateDeploymentCommand : DeploymentDto,  IRequest<DeploymentResult>
    {
    }
}