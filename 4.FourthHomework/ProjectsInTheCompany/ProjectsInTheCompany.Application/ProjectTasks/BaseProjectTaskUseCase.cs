using ProjectsInTheCompany.Domain.Exceptions.ProjectTaskExceprions;
using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks
{
    public class BaseProjectTaskUseCase
    {
        protected readonly IProjectTaskRepository projectTaskRepository;
        protected readonly IProjectRepository projectRepository;
        protected readonly ProjectTaskValidation projectTaskValidation;

        public BaseProjectTaskUseCase(IProjectTaskRepository projectTaskRepository, IProjectRepository projectRepository)
        {
            this.projectTaskRepository = projectTaskRepository;
            this.projectRepository = projectRepository;
            projectTaskValidation = new ProjectTaskValidation();
        }
    }
}
