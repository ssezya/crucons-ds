using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IReadOnlyDbContext
    {
        DbSet<User> Users { get; }

        DbSet<Error> Errors { get; }
    }
}
