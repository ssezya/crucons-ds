using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Infrastructure.Interfaces.DataAccess;

namespace DataAccess.PgSql
{
    public class AppReadOnlyDbContext : DbContext, IReadOnlyDbContext
    {
        public AppReadOnlyDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
