﻿namespace ProjectsInTheCompany.Application.Projects.Commands
{
    public class UpdateProjectCommand
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
    }
}