using ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksCreating;
using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskCreating
{
    public interface IProjectTaskCreator
    {
        void Create(AddProjectTaskCommand addProjectTaskCommand);
    }
    public class ProjectTaskCreator : BaseProjectTaskUseCase, IProjectTaskCreator
    {
        public ProjectTaskCreator(IProjectTaskRepository projectTaskRepository, IProjectRepository projectRepository) : 
            base(projectTaskRepository, projectRepository)
        {
        }

        public void Create(AddProjectTaskCommand addProjectTaskCommand)
        {
            Project project = projectRepository.GetById(addProjectTaskCommand.ProjectIds);
            projectTaskValidation.ProjectIsNull(project);

            ProjectTask projectTask = new ProjectTask(addProjectTaskCommand.Description);
            projectTask.UpdateProject(project);

            projectRepository.AddProjectTask(project, projectTask);
            projectTaskRepository.Add(projectTask);
        }
    }
}
