using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesDeleting
{
    public interface IEmployeeDeletor
    {
        void Delete(int id);
    }
    public class EmployeeDeletor : BaseEmployeeUCase, IEmployeeDeletor
    {
        public EmployeeDeletor(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository) : base(employeeRepository, projectTaskRepository)
        {
        }

        public void Delete(int id)
        {
            Employee employee = _employeeRepository.GetById(id);

            _employeeRepository.Delete(employee);
        }
    }
}
