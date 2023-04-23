using Microsoft.Extensions.DependencyInjection;
using ProjectsInTheCompany.Application.Projects.ProjectsCreating;
using ProjectsInTheCompany.Application.Projects.ProjectsDeleting;
using ProjectsInTheCompany.Application.Projects.ProjectsReceiving;
using ProjectsInTheCompany.Application.Projects.ProjectsUpdating;

namespace ProjectsInTheCompany.Application.Projects
{
    public static class ProjectsBindings
    {
        public static IServiceCollection AddProjectBindings(this IServiceCollection services)
        {
            services.AddScoped<IProjectCreator, ProjectCreator>();
            services.AddScoped<IProjectDeleter, ProjectDeleter>();
            services.AddScoped<IProjectReciever, ProjectReciever>();
            services.AddScoped<IProjectUpdater, ProjectUpdater>();

            return services;
        }
    }
}
