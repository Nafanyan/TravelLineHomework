using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Domain.Projects
{
    public class Project
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<ProjectTask> ProjectTasks { get; private set; } = new();

        public Project(string title, string description)
        {
            Title = title;
            Description = description;
        }


        public void UpdateTitle (string title)
        {
            Title = title;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

    }

}
