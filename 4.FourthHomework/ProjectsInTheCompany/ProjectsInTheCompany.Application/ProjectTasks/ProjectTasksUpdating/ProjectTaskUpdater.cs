﻿using ProjectsInTheCompany.Application.ProjectTasks.Commands;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksUpdating
{
    public interface IProjectTaskUpdater
    {
        void Update(UpdateProjectTaskCommand updateProjectTaskCommand);
    }
    public class ProjectTaskUpdater : BaseProjectTaskUCase, IProjectTaskUpdater
    {
        public ProjectTaskUpdater(IProjectTaskRepository projectTaskRepository) : base(projectTaskRepository)
        {
        }

        public void Update(UpdateProjectTaskCommand updateProjectTaskCommand)
        {
            ProjectTask projectTask = _projectTaskRepository.GetById(updateProjectTaskCommand.Id);
            projectTask.UpdateDescription(updateProjectTaskCommand.Description);
            projectTask.UpdateProject(updateProjectTaskCommand.Project);

            _projectTaskRepository.Update(projectTask);

        }
    }
}