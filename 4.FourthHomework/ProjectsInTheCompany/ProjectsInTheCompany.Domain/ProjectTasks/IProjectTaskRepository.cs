using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Domain.ProjectTasks
{
    public interface IProjectTaskRepository
    {
        List<ProjectTask> GetAll();
        ProjectTask GetById(int id);
        void Add(ProjectTask projectTask);
        void Delete(ProjectTask projectTask);
        void Update(ProjectTask projectTask);
    }
}
