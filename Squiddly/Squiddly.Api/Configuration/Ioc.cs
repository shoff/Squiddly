namespace Squiddly.Api.Configuration
{
    using Domain.Projects;
    using Microsoft.Extensions.DependencyInjection;

    public static class Ioc
    {
        public static IServiceCollection InitializeContainer(IServiceCollection services)
        {

            services.AddTransient<IProjectFactory, ProjectFactory>();

            return services;
        }
    }
}