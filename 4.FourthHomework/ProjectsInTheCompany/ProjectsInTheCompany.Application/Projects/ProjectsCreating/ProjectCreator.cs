using ProjectsInTheCompany.Application.Projects.Command;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects.ProjectsCreating
{
    public interface IProjectCreator
    {
        void Create(AddProjectCommand addProjectCommand);
    }
    public class ProjectCreator : BaseProjectUCase, IProjectCreator
    {
        public ProjectCreator(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public void Create(AddProjectCommand addProjectCommand)
        {
            Project project = new Project(addProjectCommand.Title, addProjectCommand.Description);

            _projectRepository.Add(project);
        }
    }
}
