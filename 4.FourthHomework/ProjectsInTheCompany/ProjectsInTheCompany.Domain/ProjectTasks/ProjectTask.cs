﻿using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Domain.ProjectTasks
{
    public class ProjectTask
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public int ProjectId { get; private set; }
        public Project Project { get; private set; }

        public Employee? Employee { get; private set; }

        public ProjectTask(string description)
        {
            Description = description;
        }

        public ProjectTask(string description, Project project)
        {
            Description = description;
            UpdateProject(project);
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateEmployee(Employee employee)
        {
            Employee = employee;
        }

        public void UpdateProject(Project project)
        {
            ProjectId = project.Id;
            Project = project;
        }
    }
}