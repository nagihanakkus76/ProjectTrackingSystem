using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProjectTrackingSystem.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
