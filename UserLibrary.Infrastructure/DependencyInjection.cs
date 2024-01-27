using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Application;
using System.Reflection;

namespace UserLibrary.Infrastructure
{
    /// <summary>
    /// Dependency injection related functions
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add services required by Infrastructure project
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UserLibraryDbContext>((sp, options) => options.UseSqlite(connectionString));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<UserLibraryDbContext>());

            return services;
        }
    }
}