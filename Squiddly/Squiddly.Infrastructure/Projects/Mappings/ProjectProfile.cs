namespace Squiddly.Infrastructure.Projects.Mappings
{
    using AutoMapper;
    using ChaosMonkey.Guards;
    using Data.Data;
    using Domain.Dotnet.Builds;
    using DomainProject = Domain.Projects.Project;
    using DomainBuild = Domain.Builds.Build;

    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            this.CreateMap<Build, DomainBuild>().ConvertUsing<BuildConverter>();
            this.CreateMap<Project, DomainProject>().ConvertUsing<ProjectConverter>();
        }
    }

    public class BuildConverter : ITypeConverter<Build, DomainBuild>
    {
        public DomainBuild Convert(Build source, DomainBuild destination, ResolutionContext context)
        {
            Guard.IsNotNull(source, nameof(source));
            Guard.IsNotNull(destination, nameof(destination));

            foreach (var step in source.BuildSteps)
            {
                var st = new DotnetBuildStep();
                destination.Steps.Add(st);
            }

            return destination;
        }
    }
    
    public class ProjectConverter : ITypeConverter<Project, DomainProject>
    {
        public DomainProject Convert(Project source, DomainProject destination, ResolutionContext context)
        {
            Guard.IsNotNull(source, nameof(source));
            Guard.IsNotNull(destination, nameof(destination));

            destination.DateCreated = source.DateCreated;
            destination.Description = source.Description;
            destination.Name = source.Name;
            destination.Repository = source.GitRepository;
            return destination;
        }
    }
}