using ProjectsInTheCompany.Domain.Employees;

namespace ProjectsInTheCompany.Application.Employees.EmployeesDeleting
{
    public interface IEmployeeDeletor
    {
        void Delete(int id);
    }
    public class EmployeeDeletor : BaseEmployeeUCase, IEmployeeDeletor
    {
        public EmployeeDeletor(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
        }

        public void Delete(int id)
        {
            Employee employee = _employeeRepository.GetById(id);

            _employeeRepository.Delete(employee);
        }
    }
}
