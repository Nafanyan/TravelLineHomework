using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.API.Dtos.ProjectsDtos
{
    public class ProjectDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public List<int> ProjectTasksIds { get; init; } = new();
    }
}
