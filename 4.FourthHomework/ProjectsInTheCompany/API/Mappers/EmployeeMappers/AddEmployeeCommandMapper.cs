using ProjectsInTheCompany.API.Dtos.EmployeeDtos;
using ProjectsInTheCompany.Application.Employees.EmployeesCreating;

namespace ProjectsInTheCompany.API.Mappers.EmployeeMappers
{
    public static class AddEmployeeCommandMapper
    {
        public static AddEmployeeCommand Map(this EmployeeCommandDto employeeCommandDto, int projectTaskId)
        {
            return new AddEmployeeCommand
            {
                Name = employeeCommandDto.Name,
                Surname = employeeCommandDto.Surname,
                ProjectTaskId = projectTaskId
            };
        }
    }
}
