using Microsoft.Extensions.DependencyInjection;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskCreating;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskDeleting;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskRecieving;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksUpdating;

namespace ProjectsInTheCompany.Application.ProjectTasks
{
    public static class ProjectTasksBindings
    {
        public static IServiceCollection AddProjectTasksBindings(this IServiceCollection services)
        {
            services.AddScoped<IProjectTaskCreator, ProjectTaskCreator>();
            services.AddScoped<IProjectTaskDeleter, ProjectTaskDeleter>();
            services.AddScoped<IProjectTaskReciever, ProjectTaskReciever>();
            services.AddScoped<IProjectTaskUpdater, ProjectTaskUpdater>();

            return services;
        }
    }
}
