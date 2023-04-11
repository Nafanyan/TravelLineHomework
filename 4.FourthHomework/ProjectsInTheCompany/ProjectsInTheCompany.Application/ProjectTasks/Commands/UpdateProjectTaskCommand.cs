using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.ProjectTasks.Commands
{
    public class UpdateProjectTaskCommand
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public Project Project { get; init; }
    }
}
