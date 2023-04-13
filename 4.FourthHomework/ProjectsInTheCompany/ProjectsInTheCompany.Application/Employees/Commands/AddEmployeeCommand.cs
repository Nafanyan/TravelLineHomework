﻿using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.Commands
{
    public class AddEmployeeCommand
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public ProjectTask ProjectTask { get; init; }

    }
}
