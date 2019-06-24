namespace Squiddly.Infrastructure.Projects.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Deployments;
    using Deployments.Queries;
    using MediatR;

    public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, ProjectsResult>
    {
        public Task<ProjectsResult> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}