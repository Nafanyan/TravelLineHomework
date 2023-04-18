using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesCreating
{
    public class AddEmployeeCommand
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public int ProjectTaskId { get; init; }

    }
}
