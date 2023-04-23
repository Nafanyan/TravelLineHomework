﻿using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.Employees.EmployeesUpdating
{
    public class UpdateEmployeeCommand
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public int ProjectTaskId { get; init; }
    }
}