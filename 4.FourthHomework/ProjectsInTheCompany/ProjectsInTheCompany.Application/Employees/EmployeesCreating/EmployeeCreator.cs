using ProjectsInTheCompany.Application.Employees.Commands;
using ProjectsInTheCompany.Domain.Employees;

namespace ProjectsInTheCompany.Application.Employees.EmployeesCreating
{
    public interface IEmployeeCreator
    {
        void Create(AddEmployeeCommand addEmployeeCommand);
    }
    public class EmployeeCreator : BaseEmployeeUCase, IEmployeeCreator
    {
        public EmployeeCreator(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
        }

        public void Create(AddEmployeeCommand addEmployeeCommand)
        {
            Employee employee = new Employee(addEmployeeCommand.Name, addEmployeeCommand.Surname);

            _employeeRepository.Add(employee);
        }
    }
}
