using Microsoft.Extensions.DependencyInjection;
using ProjectsInTheCompany.Application;
using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Data.Employees;
using ProjectsInTheCompany.Infrastructure.Data.Projects;
using ProjectsInTheCompany.Infrastructure.Data.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.Infrastructure
{
    public static class InfrastructureBinding
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
