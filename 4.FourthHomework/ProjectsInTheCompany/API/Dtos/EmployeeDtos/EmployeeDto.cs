using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.API.Dtos.EmployeeDtos
{
    public class EmployeeDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public int ProjectTaskId { get; init; }
    }
}
