using ProjectsInTheCompany.Domain.Employees;

namespace ProjectsInTheCompany.API.Dtos.ProjectTaskDtos
{
    public class ProjectTaskDto
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public int EmployeeId { get; init; }
    }
}
