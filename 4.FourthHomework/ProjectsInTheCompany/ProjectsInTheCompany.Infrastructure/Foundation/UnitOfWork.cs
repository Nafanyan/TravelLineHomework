using ProjectsInTheCompany.Application;

namespace ProjectsInTheCompany.Infrastructure.Foundation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectsCompanyDbContext _dbContext;

        public UnitOfWork(ProjectsCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
