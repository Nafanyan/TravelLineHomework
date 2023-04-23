using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksUpdating;

namespace ProjectsInTheCompany.API.Mappers.ProjectTaskMappers
{
    public static class UpdateProjectTaskCommandMapper
    {
        public static UpdateProjectTaskCommand Map (this ProjectTaskCommandDto projectCommandDto, int id, int projectId)
        {
            return new UpdateProjectTaskCommand
            {
                Id = id,
                Description = projectCommandDto.Description,
                ProjectId = projectId
            };
        }
    }
}
