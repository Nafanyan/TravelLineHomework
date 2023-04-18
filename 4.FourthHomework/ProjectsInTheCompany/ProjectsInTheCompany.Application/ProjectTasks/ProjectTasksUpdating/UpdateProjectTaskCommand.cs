namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksUpdating
{
    public class UpdateProjectTaskCommand
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public int ProjectId { get; init; }
    }
}
