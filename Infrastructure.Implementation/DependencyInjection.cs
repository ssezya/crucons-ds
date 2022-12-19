using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Implementation.Identity;
using Infrastructure.Implementation.Identity.Models;
using Infrastructure.Implementation.Identity.Services;
using Infrastructure.Interfaces.Identity.Services;
using Utils.Identity;

namespace Infrastructure.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region <Identity>
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PgSqlDbConnection"), x => x.MigrationsHistoryTable("__MigrationsHistory", "System")));
            services.AddIdentityCore<ApplicationIdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddRoles<ApplicationIdentityRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            #endregion

            #region <Token>
            services.AddScoped<ITokenService<TokenRequest, TokenResponse>, JwtTokenService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion

            #region <User and context>
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
            #endregion

            return services;
        }
    }
}
