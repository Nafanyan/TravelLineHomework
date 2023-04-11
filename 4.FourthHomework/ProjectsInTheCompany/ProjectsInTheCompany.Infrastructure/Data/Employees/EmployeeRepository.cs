using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.Infrastructure.Data.Employees
{
    internal class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ProjectsCompanyDbContext projectsCompanyDbContext) : base(projectsCompanyDbContext)
        {
        }

        public override Employee GetById(int id)
        {
            return _dbSet.SingleOrDefault(p => p.Id == id);
        }

        public override void Update(Employee values)
        {
            Employee employee = GetById(values.Id);

            employee.UpdateName(values.Name);
            employee.UpdateSurname(values.Surname);
            employee.UpdateProjectTask(values.ProjectTask);
        }
    }
}
