using ProjectsInTheCompany.API.Dtos.ProjectsDtos;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.API.Mappers.ProjectMappers
{
    public static class ProjectMapper
    {
        public static ProjectDto Map(this Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                ProjectTasksIds = project.ProjectTasks.Select(p => p.Id).ToList()
            };
        }
    }
}
