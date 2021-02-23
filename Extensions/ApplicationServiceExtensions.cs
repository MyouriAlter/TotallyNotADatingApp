using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TotallyNotADatingApp.DatabaseEntity;
using TotallyNotADatingApp.Interfaces;
using TotallyNotADatingApp.Services;

namespace TotallyNotADatingApp.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddDbContext<ApplicationDatabaseEntity>
            (options => options.UseSqlServer
            (
                configuration.GetConnectionString("DefaultConnection")
            ));
            
            return services;
        }
    }
}