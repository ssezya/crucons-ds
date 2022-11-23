using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IReadOnlyDbContext
    {
        DbSet<User> Users { get; }

        DbSet<Task> Tasks { get; }

        DbSet<Job> Jobs { get; }

        DbSet<Status> Statuses { get; }
    }
}
