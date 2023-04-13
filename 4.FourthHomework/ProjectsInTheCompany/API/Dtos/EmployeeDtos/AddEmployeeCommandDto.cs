using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.API.Dtos.EmployeeDtos
{
    public class AddEmployeeCommandDto
    {
        public string Name { get; init; }
        public string Surname { get; init; }
    }
}
