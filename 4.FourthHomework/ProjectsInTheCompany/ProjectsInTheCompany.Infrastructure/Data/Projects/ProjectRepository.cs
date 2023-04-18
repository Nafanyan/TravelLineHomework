using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.Infrastructure.Data.Projects
{
    internal class ProjectRepository : BaseSimpleRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectsCompanyDbContext projectsCompanyDbContext) : base(projectsCompanyDbContext)
        { 
        }
        public void AddProjectTask(Project project, ProjectTask projectTask)
        {
            project.AddProjectTask(projectTask);
        }

        public override Project GetById(int id)
        {
            return _dbSet.SingleOrDefault(p => p.Id == id);
        }

        public override void Update(Project values)
        {
            Project project = GetById(values.Id);
            project = values;
        }

    }
}
