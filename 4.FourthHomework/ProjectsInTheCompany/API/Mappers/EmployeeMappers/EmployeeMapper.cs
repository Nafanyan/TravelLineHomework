using ProjectsInTheCompany.API.Dtos.EmployeeDtos;
using ProjectsInTheCompany.Domain.Employees;

namespace ProjectsInTheCompany.API.Mappers.EmployeeMappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDto Map(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                ProjectTaskId = employee.ProjectTaskId
            };
        }
    }
}
