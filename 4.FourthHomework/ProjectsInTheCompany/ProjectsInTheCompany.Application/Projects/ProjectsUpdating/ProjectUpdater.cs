using ProjectsInTheCompany.Application.Projects.Command;
using ProjectsInTheCompany.Application.Projects.Commands;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects.ProjectsUpdating
{
    public interface IProjectUpdater
    {
        void Update(UpdateProjectCommand updateProjectCommand);
    }
    public class ProjectUpdater : BaseProjectUCase, IProjectUpdater
    {
        public ProjectUpdater(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public void Update(UpdateProjectCommand updateProjectCommand)
        {
            Project project = _projectRepository.GetById(updateProjectCommand.Id);
            project.UpdateTitle(updateProjectCommand.Title);
            project.UpdateDescription(updateProjectCommand.Description);
            
            _projectRepository.Update(project);
        }
    }
}
