namespace Squiddly.Domain.Projects
{
    using ChaosMonkey.Guards;
    using Microsoft.Extensions.Logging;

    public class ProjectFactory : IProjectFactory
    {
        private readonly ILogger<ProjectFactory> logger;

        public ProjectFactory(
            ILogger<ProjectFactory> logger)
        {
            this.logger = Guard.IsNotNull(logger, nameof(logger));
        }

        public Project CreateProject(string name)
        {
            Guard.IsNotNull(name, nameof(name));
            this.logger.LogInformation($"Creating a new domain project object '{name}'");

            return new Project
            {
                Name = name,
                Build = new Builds.Build()
            };
        }
    }
}