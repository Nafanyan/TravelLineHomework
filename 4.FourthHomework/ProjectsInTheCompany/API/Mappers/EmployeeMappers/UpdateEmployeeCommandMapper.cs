using ProjectsInTheCompany.API.Dtos.EmployeeDtos;
using ProjectsInTheCompany.Application.Employees.Commands;

namespace ProjectsInTheCompany.API.Mappers.EmployeeMappers
{
    public static class UpdateEmployeeCommandMapper
    {
        public static UpdateEmployeeCommand Map(this UpdateEmployeeCommandDto updateEmployeeCommandDto)
        {
            return new UpdateEmployeeCommand
            {
                Id = updateEmployeeCommandDto.Id,
                Name = updateEmployeeCommandDto.Name,
                Surname = updateEmployeeCommandDto.Surname
            };
        }
    }
}
