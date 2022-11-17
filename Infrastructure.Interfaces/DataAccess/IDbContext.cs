using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IDbContext : IReadOnlyDbContext
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
