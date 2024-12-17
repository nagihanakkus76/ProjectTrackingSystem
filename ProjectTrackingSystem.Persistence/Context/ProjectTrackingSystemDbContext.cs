using Microsoft.EntityFrameworkCore;
using ProjectTrackingSystem.Domain.Entities;

namespace ProjectTrackingSystem.Persistence.Context
{
    public class ProjectTrackingSystemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0P2BI1D;initial catalog=ProjectTrackingSystemDb;integrated Security=true;TrustServerCertificate=true");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
