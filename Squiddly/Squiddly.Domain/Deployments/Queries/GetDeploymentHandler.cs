namespace Squiddly.Domain.Deployments.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ChaosMonkey.Guards;
    using Data;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Zatoichi.Common.Infrastructure.Resilience;

    public class GetDeploymentHandler: IRequestHandler<GetDeploymentQuery, DeploymentResult>
    {
        private readonly IMapper mapper;
        private readonly ISquidDbContext squidDbContext;
        private readonly IExecutionPolicies executionPolicies;
        private readonly ILogger<GetDeploymentHandler> logger;

        public GetDeploymentHandler(
            IExecutionPolicies executionPolicies,
            ISquidDbContext squidDbContext,
            IMapper mapper,
            ILogger<GetDeploymentHandler> logger)
        {
            this.mapper = Guard.IsNotNull(mapper, nameof(mapper));
            this.squidDbContext = Guard.IsNotNull(squidDbContext, nameof(squidDbContext));
            this.executionPolicies = Guard.IsNotNull(executionPolicies, nameof(executionPolicies));
            this.logger = Guard.IsNotNull(logger, nameof(logger));
        }

        /// <inheritdoc />
        public async Task<DeploymentResult> Handle(GetDeploymentQuery request, CancellationToken cancellationToken)
        {
            Guard.IsNotNull(request, nameof(request));


            if (cancellationToken.IsCancellationRequested)
            {
                this.logger.LogInformation(
                    $"{this.GetType().Name} received a request to cancel getting a deployment with name: {request.DeploymentName} or Id {request.DeploymentId}");
                return await Task.FromCanceled<DeploymentResult>(cancellationToken);
            }

            var result = await this.executionPolicies.DbExecutionPolicy.ExecuteAndCaptureAsync(() =>
            {
                return this.squidDbContext.Deployments.FirstOrDefaultAsync(d =>
                    d.DeploymentId == request.DeploymentId ||
                    d.DeploymentName == request.DeploymentName, cancellationToken);
            }).ConfigureAwait(false);

            if (result.Outcome == Polly.OutcomeType.Failure)
            {
                this.logger.LogError(result.FinalException, "Error fetching deployment");
            }

            return this.mapper.Map<DeploymentResult>(result);
        }
    }
}