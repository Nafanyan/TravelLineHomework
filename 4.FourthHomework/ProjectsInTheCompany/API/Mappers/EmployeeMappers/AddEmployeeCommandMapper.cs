using ProjectsInTheCompany.API.Dtos.EmployeeDtos;
using ProjectsInTheCompany.Application.Employees.Commands;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.API.Mappers.EmployeeMappers
{
    public static class AddEmployeeCommandMapper
    {
        public static AddEmployeeCommand Map(this AddEmployeeCommandDto addEmployeeCommandDto, ProjectTask projectTask)
        {
            return new AddEmployeeCommand
            {
                Name = addEmployeeCommandDto.Name,
                Surname = addEmployeeCommandDto.Surname,
                ProjectTask = projectTask
            };
        }
    }
}
