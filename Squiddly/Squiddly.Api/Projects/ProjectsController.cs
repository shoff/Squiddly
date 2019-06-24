namespace Squiddly.Api.Projects
{
    using System;
    using System.Threading.Tasks;
    using ChaosMonkey.Guards;
    using Dtos.Projects;
    using Infrastructure.Projects.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Zatoichi.Common.Infrastructure.Extensions;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetProjectsQuery();
            var result = await this.mediator.Send(query);
            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectDto project)
        {
            throw new NotImplementedException();
        }

    }
}