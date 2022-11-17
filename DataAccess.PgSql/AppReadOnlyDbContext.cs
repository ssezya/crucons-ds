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

        public DbSet<Error> Errors { get; set; }
    }
}
