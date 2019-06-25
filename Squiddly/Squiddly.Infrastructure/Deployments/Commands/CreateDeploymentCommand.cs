namespace Squiddly.Infrastructure.Deployments.Commands
{
    using MediatR;
    using Messages.Deployments;

    public class CreateDeploymentCommand : DeploymentDto,  IRequest<DeploymentResult>
    {
    }
}