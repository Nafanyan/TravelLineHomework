using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees
{
    public class BaseEmployeeUCase
    {
        protected readonly IEmployeeRepository _employeeRepository;
        protected readonly IProjectTaskRepository _projectTaskRepository;

        public BaseEmployeeUCase(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository)
        {
            _employeeRepository = employeeRepository;
            _projectTaskRepository = projectTaskRepository;
        }
    }
}
