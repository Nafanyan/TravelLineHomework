namespace ProjectsInTheCompany.Domain.Projects
{
    public interface IProjectRepository
    {
        List<Project> GetAll();
        Project GetById(int id);
        void Add(Project project);
        void Delete(Project project);
        void Update(Project project);

    }
}
