using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; }
        DbSet<Project> Projects { get; }
        DbSet<Issue> Issues { get; }
        DbSet<Job> Jobs { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
