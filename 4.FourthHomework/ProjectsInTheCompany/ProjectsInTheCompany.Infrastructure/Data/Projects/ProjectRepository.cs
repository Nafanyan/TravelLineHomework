using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.Infrastructure.Data.Projects
{
    internal class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectsCompanyDbContext projectsCompanyDbContext) : base(projectsCompanyDbContext)
        { 
        }

        public override Project GetById(int id)
        {
            return _dbSet.SingleOrDefault(p => p.Id == id);
        }

        public override void Update(Project values)
        {
            Project project = GetById(values.Id);
            project.UpdateTitle(values.Description);
            project.UpdateDescription(values.Title);
        }
    }
}
