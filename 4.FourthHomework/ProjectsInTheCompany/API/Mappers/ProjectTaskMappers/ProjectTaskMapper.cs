using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.API.Mappers.ProjectTaskMappers
{
    public static class ProjectTaskMapper
    {
        public static ProjectTaskDto Map (this ProjectTask projectTask)
        {
            return new ProjectTaskDto
            {
                Id = projectTask.Id,
                Description = projectTask.Description,
                ProjectId = projectTask.ProjectId
            };
        }
    }
}
