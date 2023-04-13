using ProjectsInTheCompany.Application.Employees.Commands;
using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesCreating
{
    public interface IEmployeeCreator
    {
        void Create(AddEmployeeCommand addEmployeeCommand);
    }
    public class EmployeeCreator : BaseEmployeeUCase, IEmployeeCreator
    {
        public EmployeeCreator(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository) 
            : base(employeeRepository, projectTaskRepository)
        {
        }

        public void Create(AddEmployeeCommand addEmployeeCommand)
        {
            Employee employee = new Employee(addEmployeeCommand.Name, addEmployeeCommand.Surname, addEmployeeCommand.ProjectTask);

            _projectTaskRepository.AddEmployee(addEmployeeCommand.ProjectTask.Id, employee);

            _employeeRepository.Add(employee);
        }
    }
}
