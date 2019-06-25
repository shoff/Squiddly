namespace Squiddly.Infrastructure.Projects.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Dtos.Projects;
    using MediatR;
    using Zatoichi.Common.Infrastructure.Services;

    public class CreateProjectHandler : IRequestHandler<CreateProjectDto, ApiResult>
    {
        public Task<ApiResult> Handle(CreateProjectDto request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}