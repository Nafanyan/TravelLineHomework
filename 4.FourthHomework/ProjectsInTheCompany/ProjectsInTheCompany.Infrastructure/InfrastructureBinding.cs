using Microsoft.Extensions.DependencyInjection;
using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Data.Employees;
using ProjectsInTheCompany.Infrastructure.Data.Projects;
using ProjectsInTheCompany.Infrastructure.Data.ProjectTasks;

namespace ProjectsInTheCompany.Infrastructure
{
    public static class InfrastructureBinding
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
