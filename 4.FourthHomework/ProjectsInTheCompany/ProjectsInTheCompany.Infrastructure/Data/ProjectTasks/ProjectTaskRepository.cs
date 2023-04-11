using ProjectsInTheCompany.Domain.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.Infrastructure.Data.ProjectTasks
{
    internal class ProjectTaskRepository : BaseRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(ProjectsCompanyDbContext projectsCompanyDbContext) : base(projectsCompanyDbContext)
        {
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
