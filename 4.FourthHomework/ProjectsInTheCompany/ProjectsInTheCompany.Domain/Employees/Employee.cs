using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Domain.Employees
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int ProjectTaskId { get; private set; }
        public ProjectTask ProjectTask { get; private set; }

        public Employee(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Employee(string name, string surname, ProjectTask projectTask)
        {
            Name = name;
            Surname = surname;
            UpdateProjectTask(projectTask);
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateSurname(string surname)
        {
            Surname = surname;
        }

        public void UpdateProjectTask(ProjectTask projectTask)
        {
            ProjectTaskId = projectTask.Id;
            ProjectTask = projectTask;
        }
    }
}
