namespace Squiddly.Infrastructure.Projects.Queries
{
    using MediatR;
    using Messages.Projects;

    public class GetProjectsQuery : ProjectDto, IRequest<ProjectsResult>
    {
    }
}