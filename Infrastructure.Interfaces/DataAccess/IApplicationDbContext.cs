using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<Issue> Issues { get; }
        DbSet<Job> Jobs { get; }
        DbSet<Status> Statuses { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
