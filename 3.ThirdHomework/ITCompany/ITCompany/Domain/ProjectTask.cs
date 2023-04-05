
namespace ITCompany.Domain
{
    public class ProjectTask
    {
        public long TaskId { get; init; }
        public string Description { get; init; }
        public long EmployeeId { get; init; }
        public long ProjectId { get; init; }

        public ProjectTask(long taskId, string description, long employeedId, long projectId)
        {
            TaskId = taskId;
            Description = description;
            EmployeeId = employeedId;
            ProjectId = projectId;
        }
    }
}
