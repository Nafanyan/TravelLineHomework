using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksCreating
{
    public class AddProjectTaskCommand
    {
        public string Description { get; init; }
        public int ProjectIds { get; init; }
    }
}
