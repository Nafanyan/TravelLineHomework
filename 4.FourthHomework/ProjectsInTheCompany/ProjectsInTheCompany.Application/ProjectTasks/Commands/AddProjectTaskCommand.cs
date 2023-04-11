using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.ProjectTasks.Commands
{
    public class AddProjectTaskCommand
    {
        public string Description { get; init; }
        public Project Project { get; init; }
    }
}
