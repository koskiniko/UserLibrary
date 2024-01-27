using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Application;
using System.Reflection;
using MediatR.Pipeline;

namespace UserLibrary.Application
{
    /// <summary>
    /// Dependency injection related functions
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add services required by Application project
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}