using ProjectsInTheCompany.API.Dtos.ProjectsDtos;
using ProjectsInTheCompany.Application.Projects.ProjectsCreating;

namespace ProjectsInTheCompany.API.Mappers.ProjectMappers
{
    public static class AddProjectCommandMapper
    {
        public static AddProjectCommand Map(this ProjectCommandDto addProjectCommandDto)
        {
            return new AddProjectCommand
            {
                Title = addProjectCommandDto.Title,
                Description = addProjectCommandDto.Description
            };
        }
    }
}
