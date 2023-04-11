using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.Commands
{
    public class AddEmployeeCommand
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public ProjectTask ProjectTask { get; private set; }

    }
}
