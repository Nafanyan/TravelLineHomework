using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Application.ProjectTasks
{
    public class BaseProjectTaskUCase
    {
        protected readonly IProjectTaskRepository _projectTaskRepository;

        public BaseProjectTaskUCase(IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }
    }
}
