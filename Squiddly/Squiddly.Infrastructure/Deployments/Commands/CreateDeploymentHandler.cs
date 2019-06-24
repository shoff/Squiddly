namespace Squiddly.Infrastructure.Deployments.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ChaosMonkey.Guards;
    using Data;
    using Data.Data;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Zatoichi.Common.Infrastructure.Resilience;

    public class CreateDeploymentHandler : IRequestHandler<CreateDeploymentCommand, DeploymentResult>
    {
        private readonly IMapper mapper;
        private readonly ISquidDbContext squidDbContext;
        private readonly IExecutionPolicies executionPolicies;
        private readonly ILogger<CreateDeploymentHandler> logger;

        public CreateDeploymentHandler(
            IExecutionPolicies executionPolicies,
            ISquidDbContext squidDbContext,
            IMapper mapper,
            ILogger<CreateDeploymentHandler> logger)
        {
            this.mapper = mapper;
            this.squidDbContext = Guard.IsNotNull(squidDbContext, nameof(squidDbContext));
            this.executionPolicies = Guard.IsNotNull(executionPolicies, nameof(executionPolicies));
            this.logger = Guard.IsNotNull(logger, nameof(logger));
        }
        /// <inheritdoc />
        public async Task<DeploymentResult> Handle(CreateDeploymentCommand request, CancellationToken cancellationToken)
        {
            Guard.IsNotNull(request, nameof(request));

            if (cancellationToken.IsCancellationRequested)
            {
                this.logger.LogInformation(
                    $"{this.GetType().Name} received a request to cancel creating a deployment with name: {request.DeploymentName} or Id {request.DeploymentId}");
                return await Task.FromCanceled<DeploymentResult>(cancellationToken);
            }

            var result = await this.executionPolicies.DbExecutionPolicy.ExecuteAndCaptureAsync(async () =>
            {
                var deployment = this.mapper.Map<Deployment>(request);
                this.squidDbContext.Deployments.Add(deployment);
                await this.squidDbContext.SaveChangesAsync(cancellationToken);
                return deployment;
            }).ConfigureAwait(false);

            if (result.Outcome == Polly.OutcomeType.Failure)
            {
                this.logger.LogError(result.FinalException, "Error creating deployment");
            }

            return this.mapper.Map<DeploymentResult>(result);
        }
    }
}