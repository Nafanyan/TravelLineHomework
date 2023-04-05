namespace ITCompany.Domain
{
    public class Project
    {
        public long ProjectId { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long ProjectDepartamentId { get; set; }
        public List<long> TaskIDs { get; set; }

        public Project (long projectId, string title, string description)
        {
            ProjectId = projectId;
            Title = title;
            Description = description;
            TaskIDs = new();
        }
        public Project(long projectId, string title, string description, List<long> taskIDs)
        {
            ProjectId = projectId;
            Title = title;
            Description = description;
            TaskIDs = taskIDs;
        }
    }
}
