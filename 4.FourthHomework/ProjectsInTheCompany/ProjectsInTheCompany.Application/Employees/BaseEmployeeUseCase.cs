using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.Exceptions.EmployeeExceprions;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees
{
    public class BaseEmployeeUseCase
    {
        protected readonly IEmployeeRepository employeeRepository;
        protected readonly IProjectTaskRepository projectTaskRepository;
        protected readonly EmployeeValidation employeeValidation;

        public BaseEmployeeUseCase(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository)
        {
            this.employeeRepository = employeeRepository;
            this.projectTaskRepository = projectTaskRepository;
            employeeValidation = new EmployeeValidation();
        }
    }
}
