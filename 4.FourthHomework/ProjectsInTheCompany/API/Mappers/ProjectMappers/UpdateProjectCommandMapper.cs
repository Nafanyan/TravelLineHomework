using ProjectsInTheCompany.API.Dtos.ProjectsDtos;
using ProjectsInTheCompany.Application.Projects.Commands;

namespace ProjectsInTheCompany.API.Mappers.ProjectMappers
{
    public static class UpdateProjectCommandMapper
    {
        public static UpdateProjectCommand Map(this UpdateProjectCommandDto updateProjectCommandDto)
        {
            return new UpdateProjectCommand
            {
                Id = updateProjectCommandDto.Id,
                Title = updateProjectCommandDto.Title,
                Description = updateProjectCommandDto.Description
            };
        }
    }
}
