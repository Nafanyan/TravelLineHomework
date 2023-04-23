using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksCreating;

namespace ProjectsInTheCompany.API.Mappers.ProjectTaskMappers
{
    public static class AddProjectTaskCommandMapper
    {
        public static AddProjectTaskCommand Map(this ProjectTaskCommandDto projectTaskCommandDto, int projectId)
        {
            return new AddProjectTaskCommand
            {
                Description = projectTaskCommandDto.Description,
                ProjectIds = projectId
            };
        }
    }
}
