using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.Infrastructure.Data.Projects
{
    internal class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectsCompanyDbContext projectsCompanyDbContext) : base(projectsCompanyDbContext)
        { 
        }

        public override IReadOnlyList<Project> GetAll()
        {
            return _dbSet.Select(p => new Project(p.Id, 
                p.Title, 
                p.Description, 
                p.ProjectTasks))
                .ToList();
        }
        public void AddProjectTask(int id, ProjectTask projectTask)
        {
            Project project = GetById(id);
            project.AddProjectTask(projectTask);
        }

        public override Project GetById(int id)
        {
            return _dbSet.SingleOrDefault(p => p.Id == id);
        }

        public override void Update(Project values)
        {
            Project project = GetById(values.Id);
            project.UpdateTitle(values.Title);
            project.UpdateDescription(values.Description);
        }

    }
}
