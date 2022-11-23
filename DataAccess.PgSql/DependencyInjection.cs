using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces.DataAccess;
using DataAccess.PgSql;

namespace DataAccess.PgSql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessPgSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IReadOnlyDbContext, AppReadOnlyDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PgSqlConnection")));
            services.AddDbContext<IDbContext, AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PgSqlConnection")));

            return services;
        }
    }
}
