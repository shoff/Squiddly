namespace Squiddly.Infrastructure.Deployments.Commands
{
    using MediatR;

    public class CreateDeploymentCommand : DeploymentDto,  IRequest<DeploymentResult>
    {
    }
}