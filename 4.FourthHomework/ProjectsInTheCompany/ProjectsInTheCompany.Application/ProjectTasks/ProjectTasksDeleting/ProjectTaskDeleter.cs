using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskDeleting
{
    public interface IProjectTaskDeleter
    {
        void Delete(int id);
    }
    public class ProjectTaskDeleter : BaseProjectTaskUseCase, IProjectTaskDeleter
    {
        public ProjectTaskDeleter(IProjectTaskRepository projectTaskRepository, IProjectRepository projectRepository) : 
            base(projectTaskRepository, projectRepository)
        {
        }

        public void Delete(int id)
        {
            ProjectTask projectTask = projectTaskRepository.GetById(id);
            projectTaskValidation.ProjectTaskIsNull(projectTask);

            projectTaskRepository.Delete(projectTask);
        }
    }
}
