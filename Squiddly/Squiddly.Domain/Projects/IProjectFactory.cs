namespace Squiddly.Domain.Projects
{
    public interface IProjectFactory
    {
        Project CreateProject(string name);
    }
}