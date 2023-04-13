using ProjectsInTheCompany.Domain.Employees;

namespace ProjectsInTheCompany.Domain.ProjectTasks
{
    public interface IProjectTaskRepository
    {
        IReadOnlyList<ProjectTask> GetAll();
        ProjectTask GetById(int id);
        void Add(ProjectTask projectTask);
        void Delete(ProjectTask projectTask);
        void Update(ProjectTask projectTask);
        void AddEmployee(int idProjectTask, Employee employee);
    }
}
