using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Foundation;
using System.Collections.Generic;

namespace ProjectsInTheCompany.Infrastructure.Data.ProjectTasks
{
    internal class ProjectTaskRepository : BaseRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(ProjectsCompanyDbContext projectsCompanyDbContext) : base(projectsCompanyDbContext)
        {
        }

        public override IReadOnlyList<ProjectTask> GetAll()
        {
            return _dbSet.Select(pt => new ProjectTask(pt.Id, pt.Description, pt.Project, pt.Employee))
                .ToList();

        }

        public void AddEmployee(int idProjectTask, Employee employee)
        {
            ProjectTask projectTask = GetById(idProjectTask);
            projectTask.AddEmployee(employee);
        }

        public override ProjectTask GetById(int id)
        {
            return _dbSet.SingleOrDefault(p => p.Id == id);
        }

        public override void Update(ProjectTask values)
        {
            ProjectTask projectTask = GetById(values.Id);
            projectTask.UpdateDescription(values.Description);
            projectTask.UpdateProject(values.Project);
        }
    }
}
