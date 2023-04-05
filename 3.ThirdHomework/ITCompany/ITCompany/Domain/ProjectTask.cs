
namespace ITCompany.Domain
{
    public class ProjectTask
    {
        public long TaskId { get; init; }
        public string Description { get; set; }
        public long EmployeeId { get; set; }
        public long ProjectId { get; set; }

        public ProjectTask(long taskId, string description, long employeedId, long projectId)
        {
            TaskId = taskId;
            Description = description;
            EmployeeId = employeedId;
            ProjectId = projectId;
        }

    }
}
