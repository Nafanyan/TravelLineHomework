using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.API.Dtos.ProjectTaskDtos
{
    public class UpdateProjectTaskCommandDto
    {
        public int Id { get; init; }
        public string Description { get; init; }
    }
}
