using ProjectsInTheCompany.Application.Employees.Commands;
using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesUpdating
{
    public interface IEmployeeUpdater
    {
        void Update(UpdateEmployeeCommand updateEmployeeCommand);
    }
    public class EmployeeUpdater : BaseEmployeeUCase, IEmployeeUpdater
    {
        public EmployeeUpdater(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository) : base(employeeRepository, projectTaskRepository)
        {
        }

        public void Update(UpdateEmployeeCommand updateEmployeeCommand)
        {
            Employee employee = _employeeRepository.GetById(updateEmployeeCommand.Id);
            employee.UpdateName(updateEmployeeCommand.Name);
            employee.UpdateSurname(updateEmployeeCommand.Surname);
            employee.UpdateProjectTask(updateEmployeeCommand.ProjectTask);

            _employeeRepository.Update(employee);
        }
    }
}
