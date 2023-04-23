using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.Infrastructure.Data.ProjectTasks
{
    internal class ProjectTaskRepository : BaseSimpleRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(ProjectsCompanyDbContext projectsCompanyDbContext) : base(projectsCompanyDbContext)
        {
        }

        public void AddEmployee(ProjectTask projectTask, Employee employee)
        {
            projectTask.AddEmployee(employee);
        }

        public override ProjectTask GetById(int id)
        {
            return _dbSet.SingleOrDefault(p => p.Id == id);
        }

        public override void Update(ProjectTask values)
        {
            ProjectTask projectTask = GetById(values.Id);
            projectTask = values;
        }
    }
}
