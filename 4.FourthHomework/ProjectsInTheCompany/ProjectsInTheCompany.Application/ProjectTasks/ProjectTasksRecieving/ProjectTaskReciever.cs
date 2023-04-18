using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskRecieving
{
    public interface IProjectTaskReciever
    {
        IReadOnlyList<ProjectTask> GetAll();
        ProjectTask GetById(int id);
    }
    public class ProjectTaskReciever : BaseProjectTaskUseCase, IProjectTaskReciever
    {
        public ProjectTaskReciever(IProjectTaskRepository projectTaskRepository, IProjectRepository projectRepository) : 
            base(projectTaskRepository, projectRepository)
        {
        }

        public IReadOnlyList<ProjectTask> GetAll()
        {
            return projectTaskRepository.GetAll();
        }

        public ProjectTask GetById(int id)
        {
            ProjectTask projectTask = projectTaskRepository.GetById(id);
            projectTaskValidation.ProjectTaskIsNull(projectTask);

            return projectTask;
        }
    }
}
