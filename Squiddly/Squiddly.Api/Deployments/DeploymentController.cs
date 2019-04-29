
namespace Squiddly.Api.Deployments
{
    using ChaosMonkey.Guards;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    [ApiController]
    public class DeploymentController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<DeploymentController> logger;

        public DeploymentController(
            IMediator mediator,
            ILogger<DeploymentController> logger)
        {
            this.mediator = Guard.IsNotNull(mediator, nameof(mediator));
            this.logger = Guard.IsNotNull(logger, nameof(logger));
            this.logger.LogTrace("Deployment controller created.");
        }
    }
}