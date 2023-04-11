using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.Application.ProjectTasks.Commands;

namespace ProjectsInTheCompany.API.Mappers.ProjectTaskMappers
{
    public static class UpdateProjectTaskCommandMapper
    {
        public static UpdateProjectTaskCommand Map (this UpdateProjectTaskCommandDto updateProjectCommandDto)
        {
            return new UpdateProjectTaskCommand
            {
                Id = updateProjectCommandDto.Id,
                Description = updateProjectCommandDto.Description,
                Project = updateProjectCommandDto.Project
            };
        }
    }
}
