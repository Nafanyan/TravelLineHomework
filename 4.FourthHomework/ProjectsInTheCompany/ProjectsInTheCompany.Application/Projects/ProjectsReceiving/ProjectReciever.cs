using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects.ProjectsReceiving
{

    public interface IProjectReciever
    {
        IReadOnlyList<Project> GetAll();
        Project GetById(int id);
    }
    public class ProjectReciever : BaseProjectUCase, IProjectReciever
    {
        public ProjectReciever(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public IReadOnlyList<Project> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public Project GetById(int id)
        {
            return _projectRepository.GetById(id);
        }
    }
}
