using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesReceiving
{
    public interface IEmployeeReciever
    {
        IReadOnlyList<Employee> GetAll();
        Employee GetById(int id);
    }
    public class EmployeeReciever : BaseEmployeeUCase, IEmployeeReciever
    {
        public EmployeeReciever(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository) : base(employeeRepository, projectTaskRepository)
        {
        }

        public IReadOnlyList<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }
    }
}
