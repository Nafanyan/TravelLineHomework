using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskRecieving
{
    public interface IProjectTaskReciever
    {
        IReadOnlyList<ProjectTask> GetAll();
        ProjectTask GetById(int id);
    }
    public class ProjectTaskReciever : BaseProjectTaskUCase, IProjectTaskReciever
    {
        public ProjectTaskReciever(IProjectTaskRepository projectTaskRepository) : base(projectTaskRepository)
        {
        }

        public IReadOnlyList<ProjectTask> GetAll()
        {
            return _projectTaskRepository.GetAll();
        }

        public ProjectTask GetById(int id)
        {
            return _projectTaskRepository.GetById(id);
        }
    }
}
