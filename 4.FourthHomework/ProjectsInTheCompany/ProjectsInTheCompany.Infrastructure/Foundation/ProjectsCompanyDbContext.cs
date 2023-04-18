using Microsoft.EntityFrameworkCore;
using ProjectsInTheCompany.Infrastructure.Data.Employees;
using ProjectsInTheCompany.Infrastructure.Data.Projects;
using ProjectsInTheCompany.Infrastructure.Data.ProjectTasks;

namespace ProjectsInTheCompany.Infrastructure.Foundation
{
    public class ProjectsCompanyDbContext : DbContext
    {
        public ProjectsCompanyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectConfiguration).Assembly);
        }
    }
}
