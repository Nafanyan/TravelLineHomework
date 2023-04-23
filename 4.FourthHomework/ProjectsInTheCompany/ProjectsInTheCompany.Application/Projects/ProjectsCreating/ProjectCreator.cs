using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects.ProjectsCreating
{
    public interface IProjectCreator
    {
        void Create(AddProjectCommand addProjectCommand);
    }
    public class ProjectCreator : BaseProjectUseCase, IProjectCreator
    {
        public ProjectCreator(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public void Create(AddProjectCommand addProjectCommand)
        {
            Project project = new Project(addProjectCommand.Title, addProjectCommand.Description);

            projectRepository.Add(project);
        }
    }
}
