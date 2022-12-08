using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces.DataAccess;

namespace DataAccess.PgSql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessPgSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PgSqlDbConnection")));

            return services;
        }
    }
}
