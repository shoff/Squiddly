namespace Squiddly.Domain.Deployments.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class CreateDeploymentHandler : IRequestHandler<CreateDeployment, DeploymentResult>
    {
        /// <inheritdoc />
        public Task<DeploymentResult> Handle(CreateDeployment request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}