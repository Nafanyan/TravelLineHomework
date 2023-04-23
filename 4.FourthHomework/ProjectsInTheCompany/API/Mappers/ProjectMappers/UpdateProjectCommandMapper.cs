using ProjectsInTheCompany.API.Dtos.ProjectsDtos;
using ProjectsInTheCompany.Application.Projects.ProjectsUpdating;

namespace ProjectsInTheCompany.API.Mappers.ProjectMappers
{
    public static class UpdateProjectCommandMapper
    {
        public static UpdateProjectCommand Map(this ProjectCommandDto projectCommandDto, int id)
        {
            return new UpdateProjectCommand
            {
                Id = id,
                Title = projectCommandDto.Title,
                Description = projectCommandDto.Description
            };
        }
    }
}
