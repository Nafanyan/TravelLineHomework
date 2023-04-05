using ITCompany.Domain;

namespace ITCompany.DTO
{
    public class CreateProjectDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<long> TaskIds { get; set; }
        //public List<ProjectTasks> ProjectTasks { get; set; }
    }
}
