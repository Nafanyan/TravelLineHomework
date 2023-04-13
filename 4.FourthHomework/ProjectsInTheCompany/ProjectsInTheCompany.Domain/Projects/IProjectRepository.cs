using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Domain.Projects
{
    public interface IProjectRepository
    {
        IReadOnlyList<Project> GetAll();
        Project GetById(int id);
        void Add(Project project);
        void Delete(Project project);
        void Update(Project project);
        void AddProjectTask(int id, ProjectTask projectTask);

    }
}
