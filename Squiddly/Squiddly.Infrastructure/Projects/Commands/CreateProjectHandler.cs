namespace Squiddly.Infrastructure.Projects.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ChaosMonkey.Guards;
    using Data;
    using Domain.Projects;
    using Dtos.Projects;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Zatoichi.Common.Infrastructure.Services;

    public class CreateProjectHandler : IRequestHandler<CreateProjectDto, ApiResult>
    {
        private readonly IMapper mapper;
        private readonly ISquidDbContext squidDbContext;
        private readonly ILogger<CreateProjectHandler> logger;
        private readonly IProjectFactory projectFactory;

        public CreateProjectHandler(
            ILogger<CreateProjectHandler> logger,
            IMapper mapper,
            IProjectFactory projectFactory,
            ISquidDbContext squidDbContext )
        {
            this.mapper = Guard.IsNotNull(mapper, nameof(mapper));
            this.squidDbContext = Guard.IsNotNull(squidDbContext, nameof(squidDbContext));
            this.logger = Guard.IsNotNull(logger, nameof(logger));
            this.projectFactory = Guard.IsNotNull(projectFactory, nameof(projectFactory));
        }

        public Task<ApiResult> Handle(CreateProjectDto request, 
            CancellationToken cancellationToken)
        {
            var project = this.projectFactory.CreateProject(request.Name);

            return Task.FromResult(new ApiResult(System.Net.HttpStatusCode.OK, null));
        }
    }
}