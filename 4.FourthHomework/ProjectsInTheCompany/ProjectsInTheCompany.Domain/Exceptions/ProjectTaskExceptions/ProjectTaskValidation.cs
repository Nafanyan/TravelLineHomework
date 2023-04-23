using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.Domain.Exceptions.ProjectTaskExceprions
{
    public class ProjectTaskValidation
    {
        public void ProjectIsNull(Project project)
        {
            if (project == null)
            {
                throw new ProjectTaskException("Project is null");
            }
        }
        public void ProjectTaskIsNull(ProjectTask project)
        {
            if (project == null)
            {
                throw new ProjectTaskException("ProjectTask is null");
            }
        }
    }
}
