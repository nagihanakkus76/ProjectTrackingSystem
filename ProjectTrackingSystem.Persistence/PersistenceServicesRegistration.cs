using Microsoft.Extensions.DependencyInjection;
using ProjectTrackingSystem.Application.Repositories;
using ProjectTrackingSystem.Persistence.Context;
using ProjectTrackingSystem.Persistence.Repositories;

namespace ProjectTrackingSystem.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddDbContext<ProjectTrackingSystemDbContext>();
            return services;
        }
    }
}
