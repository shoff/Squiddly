namespace Squiddly.Data
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class SquidDbContext : DbContext, ISquidDbContext
    {
        public SquidDbContext() { }

        public SquidDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;database=Squiddly;trusted_connection=yes;MultipleActiveResultSets=true");
            }


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(u => u.IssueId);
                entity.HasOne(i => i.Deployment);
            });

            modelBuilder.Entity<Deployment>(entity => { entity.HasMany<Issue>().WithOne("Deployment"); });
        }

        public DbSet<Deployment> Deployments { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Build>Builds { get; set; }
        public DbSet<BuildStep> BuildSteps { get; set; }
        public DbSet<GitCredential> Credentials { get; set; }

    }
}