using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskDeleting
{
    public interface IProjectTaskDeleter
    {
        void Delete(int id);
    }
    public class ProjectTaskDeleter : BaseProjectTaskUCase, IProjectTaskDeleter
    {
        public ProjectTaskDeleter(IProjectTaskRepository projectTaskRepository) : base(projectTaskRepository)
        {
        }

        public void Delete(int id)
        {
            ProjectTask projectTask = _projectTaskRepository.GetById(id);

            _projectTaskRepository.Delete(projectTask);
        }
    }
}
