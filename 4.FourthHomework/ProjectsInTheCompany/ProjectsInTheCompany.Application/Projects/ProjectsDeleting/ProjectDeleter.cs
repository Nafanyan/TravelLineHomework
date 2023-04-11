using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects.ProjectsDeleting
{
    public interface IProjectDeleter
    {
        void Delete(int id);
    }
    public class ProjectDeleter : BaseProjectUCase, IProjectDeleter
    {
        public ProjectDeleter(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public void Delete(int id)
        {
            Project project = _projectRepository.GetById(id);

            _projectRepository.Delete(project);
        }
    }
}
