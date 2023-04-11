using ProjectsInTheCompany.Application.ProjectTasks.Commands;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskCreating
{
    public interface IProjectTaskCreator
    {
        void Create(AddProjectTaskCommand addProjectTaskCommand);
    }
    public class ProjectTaskCreator : BaseProjectTaskUCase, IProjectTaskCreator
    {
        public ProjectTaskCreator(IProjectTaskRepository projectTaskRepository) : base(projectTaskRepository)
        {
        }

        public void Create(AddProjectTaskCommand addProjectTaskCommand)
        {
            ProjectTask projectTask = new ProjectTask(addProjectTaskCommand.Description, addProjectTaskCommand.Project);

            _projectTaskRepository.Add(projectTask);
        }
    }
}
