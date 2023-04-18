using ProjectsInTheCompany.Domain.Exceptions.ProjectExceptions;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects
{
    public class BaseProjectUseCase
    {
        protected readonly IProjectRepository projectRepository;
        protected readonly ProjectValidation projectValidation;

        public BaseProjectUseCase(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
            projectValidation = new ProjectValidation();
        }
    }
}
