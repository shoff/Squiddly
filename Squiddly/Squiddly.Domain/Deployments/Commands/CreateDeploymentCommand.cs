namespace Squiddly.Domain.Deployments.Commands
{
    using Infrastructure.Deployments;
    using MediatR;

    public class CreateDeploymentCommand : DeploymentDto,  IRequest<DeploymentResult>
    {
    }
}