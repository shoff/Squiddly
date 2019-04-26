namespace Squiddly.Data
{
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public interface ISquidDbContext
    {
        DbSet<Deployment> Deployments { get; set; }
        DbSet<Issue> Issues { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}