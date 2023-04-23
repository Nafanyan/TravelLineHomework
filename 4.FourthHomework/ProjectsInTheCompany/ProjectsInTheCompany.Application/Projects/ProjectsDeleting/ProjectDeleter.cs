using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects.ProjectsDeleting
{
    public interface IProjectDeleter
    {
        void Delete(int id);
    }
    public class ProjectDeleter : BaseProjectUseCase, IProjectDeleter
    {
        public ProjectDeleter(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public void Delete(int id)
        {
            Project project = projectRepository.GetById(id);
            projectValidation.ProjectIsNull(project);

            projectRepository.Delete(project);
        }
    }
}
