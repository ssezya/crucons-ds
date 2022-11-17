using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces.DataAccess;

namespace DataAccess.PgSql
{
    public class AppDbContext : AppReadOnlyDbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
        }
    }
}
