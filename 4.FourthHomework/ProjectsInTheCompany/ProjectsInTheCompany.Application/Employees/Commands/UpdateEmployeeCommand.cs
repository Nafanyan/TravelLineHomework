using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.Commands
{
    public class UpdateEmployeeCommand
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public ProjectTask ProjectTask { get; private set; }
    }
}
