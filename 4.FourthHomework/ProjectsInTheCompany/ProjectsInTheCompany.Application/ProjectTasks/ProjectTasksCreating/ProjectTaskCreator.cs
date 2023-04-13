using ProjectsInTheCompany.Application.ProjectTasks.Commands;
using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskCreating
{
    public interface IProjectTaskCreator
    {
        void Create(AddProjectTaskCommand addProjectTaskCommand);
    }
    public class ProjectTaskCreator : BaseProjectTaskUCase, IProjectTaskCreator
    {
        public ProjectTaskCreator(IProjectTaskRepository projectTaskRepository, IProjectRepository projectRepository) : 
            base(projectTaskRepository, projectRepository)
        {
        }

        public void Create(AddProjectTaskCommand addProjectTaskCommand)
        {
            ProjectTask projectTask = new ProjectTask(addProjectTaskCommand.Description, addProjectTaskCommand.Project);

            _projectRepository.AddProjectTask(addProjectTaskCommand.Project.Id, projectTask);

            _projectTaskRepository.Add(projectTask);
        }
    }
}
