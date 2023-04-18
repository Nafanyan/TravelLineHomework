using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesDeleting
{
    public interface IEmployeeDeletor
    {
        void Delete(int id);
    }
    public class EmployeeDeletor : BaseEmployeeUseCase, IEmployeeDeletor
    {
        public EmployeeDeletor(IEmployeeRepository employeeRepository, IProjectTaskRepository projectTaskRepository) : base(employeeRepository, projectTaskRepository)
        {
        }

        public void Delete(int id)
        {
            Employee employee = employeeRepository.GetById(id);
            employeeValidation.EmployeeIsNull(employee);

            employeeRepository.Delete(employee);
        }
    }
}
