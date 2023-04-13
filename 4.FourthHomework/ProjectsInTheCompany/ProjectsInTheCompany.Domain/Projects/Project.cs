using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Domain.Projects
{
    public class Project
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<ProjectTask> ProjectTasks { get; private set; }


        public Project(string title, string description)
        {
            Title = title;
            Description = description;
            ProjectTasks = new List<ProjectTask>();
        }
        public Project(int id, string title, string description, List<ProjectTask> projectTasks)
        {
            Id = id;
            Title = title;
            Description = description;
            ProjectTasks = projectTasks;
        }

        public void UpdateTitle (string title)
        {
            Title = title;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void AddProjectTask(ProjectTask projectTasks)
        {
            if (!ProjectTasks.Contains(projectTasks))
            {
                ProjectTasks.Add(projectTasks);
            }
        }
    }

}
