using System.Reflection;

namespace UserLibrary.API
{
    /// <summary>
    /// Dependency injection related functions
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add services required by Api project
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddExceptionHandler<CustomExceptionHandler>();
            return services;
        }
    }
}