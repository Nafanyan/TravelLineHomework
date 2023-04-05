using ITCompany.Domain;
using ITCompany.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ITCompany.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private static readonly List<Project> _projects = new();
        private static long _id = 0;

        /// <summary>
        /// Создает новый проект
        /// </summary>
        /// <param name="createProjectDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] CreateProjectDTO createProjectDTO)
        {
            _id++;
            Project project = new Project(_id, createProjectDTO.Title, createProjectDTO.Description);
            _projects.Add(project);

            return Ok();
        }

        /// <summary>
        /// Возвращает список проектов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _projects.Select(p => new
            {
                p.ProjectId,
                p.Title,
                p.Description,
                p.TaskIDs
            }).OrderBy(p => p.ProjectId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _projects.Where(p => p.ProjectId == id).FirstOrDefault();
            return Ok(result);
        }

        /// <summary>
        /// Обновляет проект по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createProjectDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutById(long id, [FromBody] CreateProjectDTO createProjectDTO)
        {
            SendDataToProjectTask(id);
            _projects.Remove(_projects.Where(p => p.ProjectId == id).FirstOrDefault());

            Project project = new Project(id, createProjectDTO.Title, createProjectDTO.Description);

            _projects.Add(project);
            return Ok();
        }

        /// <summary>
        /// Удаляет проект по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createProjectDTO"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id, [FromBody] CreateProjectDTO createProjectDTO)
        {
            _projects.Remove(_projects.Where(p => p.ProjectId == id).FirstOrDefault());

            return Ok();
        }

        /// <summary>
        /// Позволяет принимать обновленные данные из контроллера ProjectTasksController для актуальности данных
        /// </summary>
        /// <param name="createProjectDTO"></param>
        /// <param name="projectId"></param>
        public static void UpdatingFromProjectTusk(CreateProjectDTO createProjectDTO, long projectId)
        {
            Project project = _projects.Where(p => p.ProjectId == projectId).FirstOrDefault();
            List<long> projectTasksId = createProjectDTO.TaskIds;
            project.TaskIDs = projectTasksId;
        }

        /// <summary>
        /// Позволяет отправлять обновленные данные в контроллер ProjectTasksController для актуальности данных
        /// </summary>
        /// <param name="idProject"></param>
        private void SendDataToProjectTask(long idProject)
        {
            foreach (long projectTaskId in _projects.Where(p => p.ProjectId == idProject).FirstOrDefault().TaskIDs)
            {
                ProjectTasksController.UpdatingFromProject(projectTaskId);
            }
        }

    }
}
