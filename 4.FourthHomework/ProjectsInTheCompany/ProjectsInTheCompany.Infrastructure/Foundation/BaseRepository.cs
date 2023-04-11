using Microsoft.EntityFrameworkCore;

namespace ProjectsInTheCompany.Infrastructure.Foundation
{
    internal class BaseRepository<T> where T : class
    {
        private readonly ProjectsCompanyDbContext _projectsCompanyDbContext;
        private DbSet<T> _dbSet => _projectsCompanyDbContext.Set<T>();

        BaseRepository(ProjectsCompanyDbContext projectsCompanyDbContext)
        {
            _projectsCompanyDbContext = projectsCompanyDbContext;
        }
    }
}
