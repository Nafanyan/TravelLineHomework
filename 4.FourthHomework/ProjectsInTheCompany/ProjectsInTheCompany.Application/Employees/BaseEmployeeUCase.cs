using ProjectsInTheCompany.Domain.Employees;

namespace ProjectsInTheCompany.Application.Employees
{
    public class BaseEmployeeUCase
    {
        protected readonly IEmployeeRepository _employeeRepository;

        public BaseEmployeeUCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    }
}
