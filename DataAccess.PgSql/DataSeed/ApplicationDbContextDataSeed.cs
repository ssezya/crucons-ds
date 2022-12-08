using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace DataAccess.PgSql.DataSeed
{
    internal static class ApplicationDbContextDataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            Status[] newStatuses =
            {
                new Status
                {
                    StatusId = 1,
                    Name = "New",
                    ActionName = "Input"
                },
                new Status
                {
                    StatusId = 2,
                    Name = "Open",
                    ActionName = "Opening"
                },
                new Status
                {
                    StatusId = 3,
                    Name = "Solved",
                    ActionName = "Solution"
                },
                new Status
                {
                    StatusId = 4,
                    Name = "Closed",
                    ActionName = "Closure"
                }
            };

            builder.Entity<Status>().HasData(newStatuses);
        }
    }
}
