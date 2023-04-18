using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksUpdating
{
    public interface IProjectTaskUpdater
    {
        void Update(UpdateProjectTaskCommand updateProjectTaskCommand);
    }
    public class ProjectTaskUpdater : BaseProjectTaskUseCase, IProjectTaskUpdater
    {
        public ProjectTaskUpdater(IProjectTaskRepository projectTaskRepository, IProjectRepository projectRepository) : 
            base(projectTaskRepository, projectRepository)
        {
        }

        public void Update(UpdateProjectTaskCommand updateProjectTaskCommand)
        {
            Project project = projectRepository.GetById(updateProjectTaskCommand.ProjectId);
            projectTaskValidation.ProjectIsNull(project);

            ProjectTask projectTask = projectTaskRepository.GetById(updateProjectTaskCommand.Id);
            projectTaskValidation.ProjectTaskIsNull(projectTask);

            projectTask.UpdateDescription(updateProjectTaskCommand.Description);
            projectTask.UpdateProject(project);

            projectTaskRepository.Update(projectTask);
        }
    }
}
