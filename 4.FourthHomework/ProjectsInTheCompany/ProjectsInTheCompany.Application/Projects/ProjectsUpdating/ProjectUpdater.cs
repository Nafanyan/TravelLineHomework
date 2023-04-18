using ProjectsInTheCompany.Domain.Exceptions.ProjectExceptions;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Application.Projects.ProjectsUpdating
{
    public interface IProjectUpdater
    {
        void Update(UpdateProjectCommand updateProjectCommand);
    }
    public class ProjectUpdater : BaseProjectUseCase, IProjectUpdater
    {
        public ProjectUpdater(IProjectRepository projectRepository) : base(projectRepository)
        {
        }

        public void Update(UpdateProjectCommand updateProjectCommand)
        {
            Project project = projectRepository.GetById(updateProjectCommand.Id);
            projectValidation.ProjectIsNull(project);

            project.UpdateTitle(updateProjectCommand.Title);
            project.UpdateDescription(updateProjectCommand.Description);
            projectRepository.Update(project);
        }
    }
}
