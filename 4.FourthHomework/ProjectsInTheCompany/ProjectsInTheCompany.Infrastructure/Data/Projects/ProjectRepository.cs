using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.Infrastructure.Data.Projects
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(ProjectsCompanyDbContext projectsCompanyDbContext) : base(projectsCompanyDbContext)
        {

        }

        public void Add(Project project)
        {
            throw new NotImplementedException();
        }

        public void Delete(Project project)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public Project GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
