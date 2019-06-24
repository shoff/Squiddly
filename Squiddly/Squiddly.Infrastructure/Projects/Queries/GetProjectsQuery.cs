namespace Squiddly.Infrastructure.Projects.Queries
{
    using Dtos;
    using Dtos.Projects;
    using MediatR;

    public class GetProjectsQuery : ProjectDto, IRequest<ProjectsResult>
    {
    }
}