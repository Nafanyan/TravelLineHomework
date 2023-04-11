using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.Application.ProjectTasks.Commands;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.API.Mappers.ProjectTaskMappers
{
    public static class AddProjectTaskCommandMapper
    {
        public static AddProjectTaskCommand Map(this AddProjectTaskCommandDto addProjectTaskCommandDto, Project project)
        {
            return new AddProjectTaskCommand
            {
                Description = addProjectTaskCommandDto.Description,
                Project = project
            };
        }
    }
}
