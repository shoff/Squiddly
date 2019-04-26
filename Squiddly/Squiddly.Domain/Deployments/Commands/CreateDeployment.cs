namespace Squiddly.Domain.Deployments.Commands
{
    using Infrastructure.Deployments;
    using MediatR;

    public class CreateDeployment : DeploymentDto,  IRequest<DeploymentResult>
    {
    }
}