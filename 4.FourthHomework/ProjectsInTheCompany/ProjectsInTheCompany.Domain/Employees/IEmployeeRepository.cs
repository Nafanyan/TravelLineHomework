using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Domain.Employees
{
    public interface IEmployeeRepository
    {
        IReadOnlyList<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Delete(Employee employee);
        void Update(Employee employee);
    }
}
