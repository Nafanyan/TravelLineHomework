using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesReceiving
{
    public interface IEmployeeReciever
    {
        IReadOnlyList<Employee> GetAll();
        Employee GetById(int id);
    }
    public class EmployeeReciever : BaseEmployeeUseCase, IEmployeeReciever
    {
        public EmployeeReciever(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository) : base(employeeRepository, projectTaskRepository)
        {
        }

        public IReadOnlyList<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            Employee employee = employeeRepository.GetById(id);
            employeeValidation.EmployeeIsNull(employee);
            return employee;
        }
    }
}
