using ProjectsInTheCompany.API.Dtos.EmployeeDtos;
using ProjectsInTheCompany.Application.Employees.EmployeesUpdating;

namespace ProjectsInTheCompany.API.Mappers.EmployeeMappers
{
    public static class UpdateEmployeeCommandMapper
    {
        public static UpdateEmployeeCommand Map(this EmployeeCommandDto employeeCommandDto, int id, int projectTaskId)
        {
            return new UpdateEmployeeCommand
            {
                Id = id,
                Name = employeeCommandDto.Name,
                Surname = employeeCommandDto.Surname,
                ProjectTaskId = projectTaskId
            };
        }
    }
}
