namespace Squiddly.Api.Projects
{
    using ChaosMonkey.Guards;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<ProjectsController> logger;

        public ProjectsController(
            IMediator mediator,
            ILogger<ProjectsController> logger)
        {
            this.mediator = Guard.IsNotNull(mediator, nameof(mediator));
            this.logger = Guard.IsNotNull(logger, nameof(logger));
            this.logger.LogTrace("Projects controller created.");
        }
    }
}