using ProjectsInTheCompany.API.Dtos.ProjectsDtos;
using ProjectsInTheCompany.Application.Projects.Command;

namespace ProjectsInTheCompany.API.Mappers.ProjectMappers
{
    public static class AddProjectCommandMapper
    {
        public static AddProjectCommand Map(this AddProjectCommandDto addProjectCommandDto)
        {
            return new AddProjectCommand
            {
                Title = addProjectCommandDto.Title,
            };
        }
    }
}
