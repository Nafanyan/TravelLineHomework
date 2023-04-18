using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesCreating
{
    public interface IEmployeeCreator
    {
        void Create(AddEmployeeCommand addEmployeeCommand);
    }
    public class EmployeeCreator : BaseEmployeeUseCase, IEmployeeCreator
    {
        public EmployeeCreator(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository) 
            : base(employeeRepository, projectTaskRepository)
        {
        }

        public void Create(AddEmployeeCommand addEmployeeCommand)
        {
            ProjectTask projectTask = projectTaskRepository.GetById(addEmployeeCommand.ProjectTaskId);
            employeeValidation.ProjectTaskIsNull(projectTask);

            Employee employee = new Employee(addEmployeeCommand.Name, addEmployeeCommand.Surname, projectTask);
            employeeValidation.EmployeeIsNull(employee);

            projectTaskRepository.AddEmployee(projectTask, employee);
            employeeRepository.Add(employee);
        }
    }
}
