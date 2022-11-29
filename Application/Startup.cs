using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using DataAccess.PgSql;
using UseCases;
using Application.Utils;

namespace Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ValidatorOptions.Global.LanguageManager.Enabled = false; // Disable localization support
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccessPgSql(Configuration);
            services.AddUseCases();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandlerMiddleware();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
