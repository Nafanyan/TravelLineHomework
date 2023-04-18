using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.Domain.Exceptions.ProjectExceptions
{
    public class ProjectValidation
    {
        public void ProjectIsNull(Project project)
        {
            if (project == null)
            {
                throw new ProjectException("Project is null");
            }
        }
    }
}
