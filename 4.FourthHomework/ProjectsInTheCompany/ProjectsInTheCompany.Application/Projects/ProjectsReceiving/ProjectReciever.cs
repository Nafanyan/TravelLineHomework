using ProjectsInTheCompany.Domain.Exceptions.ProjectExceptions;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects.ProjectsReceiving
{

    public interface IProjectReciever
    {
        IReadOnlyList<Project> GetAll();
        Project GetById(int id);
    }
    public class ProjectReciever : BaseProjectUseCase, IProjectReciever
    {
        public ProjectReciever(IProjectRepository projectRepository) 
            : base(projectRepository)
        {
        }

        public IReadOnlyList<Project> GetAll()
        {
            return projectRepository.GetAll();
        }

        public Project GetById(int id)
        {
            Project project = projectRepository.GetById(id);
            projectValidation.ProjectIsNull(project);
            return project;
        }
    }
}
