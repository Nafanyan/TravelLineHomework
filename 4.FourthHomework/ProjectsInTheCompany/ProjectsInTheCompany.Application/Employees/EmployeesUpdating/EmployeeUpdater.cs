using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesUpdating
{
    public interface IEmployeeUpdater
    {
        void Update(UpdateEmployeeCommand updateEmployeeCommand);
    }
    public class EmployeeUpdater : BaseEmployeeUseCase, IEmployeeUpdater
    {
        public EmployeeUpdater(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository) : base(employeeRepository, projectTaskRepository)
        {
        }

        public void Update(UpdateEmployeeCommand updateEmployeeCommand)
        {
            ProjectTask projectTask = projectTaskRepository.GetById(updateEmployeeCommand.ProjectTaskId);
            employeeValidation.ProjectTaskIsNull(projectTask);

            Employee employee = employeeRepository.GetById(updateEmployeeCommand.Id);
            employeeValidation.EmployeeIsNull(employee);

            employee.UpdateName(updateEmployeeCommand.Name);
            employee.UpdateSurname(updateEmployeeCommand.Surname);
            employee.UpdateProjectTask(projectTask);
            employeeRepository.Update(employee);
        }
    }
}
