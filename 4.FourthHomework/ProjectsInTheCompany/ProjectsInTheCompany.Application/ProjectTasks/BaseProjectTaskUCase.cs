using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks
{
    public class BaseProjectTaskUCase
    {
        protected readonly IProjectTaskRepository _projectTaskRepository;
        protected readonly IProjectRepository _projectRepository;

        public BaseProjectTaskUCase(IProjectTaskRepository projectTaskRepository, IProjectRepository projectRepository)
        {
            _projectTaskRepository = projectTaskRepository;
            _projectRepository = projectRepository;
        }
    }
}
