using Microsoft.Extensions.DependencyInjection;
using ProjectsInTheCompany.Application.Employees.EmployeesCreating;
using ProjectsInTheCompany.Application.Employees.EmployeesDeleting;
using ProjectsInTheCompany.Application.Employees.EmployeesReceiving;
using ProjectsInTheCompany.Application.Employees.EmployeesUpdating;

namespace ProjectsInTheCompany.Application.Employees
{
    public static class EmployeesBindings
    {
        public static IServiceCollection AddEmployeesBindings(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeCreator, EmployeeCreator>();
            services.AddScoped<IEmployeeDeletor, EmployeeDeletor>();
            services.AddScoped<IEmployeeReciever, EmployeeReciever>();
            services.AddScoped<IEmployeeUpdater, EmployeeUpdater>();

            return services;
        }
    }
}
