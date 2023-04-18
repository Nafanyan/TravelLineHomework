using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.Exceptions.ProjectTaskExceprions;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Domain.Exceptions.EmployeeExceprions
{
    public class EmployeeValidation
    {
        public void ProjectTaskIsNull(ProjectTask project)
        {
            if (project == null)
            {
                throw new EmployeeException("ProjectTask is null");
            }
        }
        public void EmployeeIsNull(Employee employee)
        {
            if (employee == null)
            {
                throw new EmployeeException("Employee is null");
            }
        }
    }
}
