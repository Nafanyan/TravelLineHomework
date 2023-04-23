using Microsoft.EntityFrameworkCore;

namespace ProjectsInTheCompany.Infrastructure.Foundation
{
    internal abstract class BaseSimpleRepository<T> where T : class
    {
        private readonly ProjectsCompanyDbContext _projectsCompanyDbContext;
        protected DbSet<T> _dbSet => _projectsCompanyDbContext.Set<T>();

        protected BaseSimpleRepository(ProjectsCompanyDbContext projectsCompanyDbContext)
        {
            _projectsCompanyDbContext = projectsCompanyDbContext;
        }

        public abstract T GetById(int id);
        public abstract void Update(T values);
        public virtual IReadOnlyList<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public virtual void Add(T values)
        {
            _dbSet.Add(values);
        }
        public virtual void Delete(T values)
        {
            _dbSet.Remove(values);
        }
    }
}
