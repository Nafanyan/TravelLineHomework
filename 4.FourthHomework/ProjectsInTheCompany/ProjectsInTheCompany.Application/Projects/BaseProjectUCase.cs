using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects
{
    public class BaseProjectUCase
    {
        protected readonly IProjectRepository _projectRepository;

        public BaseProjectUCase(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
    }
}
