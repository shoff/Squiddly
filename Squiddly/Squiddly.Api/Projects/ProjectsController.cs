namespace Squiddly.Api.Projects
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using ChaosMonkey.Guards;
    using Infrastructure.Projects.Queries;
    using MediatR;
    using Messages.Projects;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Zatoichi.Common.Infrastructure.Extensions;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly ILogger<ProjectsController> logger;

        public ProjectsController(
            IMapper mapper,
            IMediator mediator,
            ILogger<ProjectsController> logger)
        {
            this.mapper = Guard.IsNotNull(mapper, nameof(mapper));
            this.mediator = Guard.IsNotNull(mediator, nameof(mediator));
            this.logger = Guard.IsNotNull(logger, nameof(logger));
            this.logger.LogTrace("Projects controller created.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var query = new GetProjectsQuery();
            var result = await this.mediator.Send(query);
            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDto project)
        {
            throw new NotImplementedException();
        }

    }
}