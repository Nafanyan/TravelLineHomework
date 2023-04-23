using Microsoft.Extensions.DependencyInjection;
using ProjectsInTheCompany.Application.Employees;
using ProjectsInTheCompany.Application.Projects;
using ProjectsInTheCompany.Application.ProjectTasks;

namespace ProjectsInTheCompany.Application
{
    public static class ApplicationBinding
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddProjectBindings();
            services.AddProjectTasksBindings();
            services.AddEmployeesBindings();

            return services;
        }
    }
}
