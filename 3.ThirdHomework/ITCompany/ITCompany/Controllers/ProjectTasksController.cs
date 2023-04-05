using ITCompany.Domain;
using ITCompany.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace ITCompany.Controllers
{
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {
        private static readonly List<ProjectTask> _projectTasks = new();
        private static long _id = 0;

        /// <summary>
        /// Создает новую задачу
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="createProjectTaskDTO"></param>
        /// <returns></returns>
        [HttpPost("project/{projectId}/[controller]")]
        public IActionResult Create(int projectId, [FromBody] CreateProjectTaskDTO createProjectTaskDTO)
        {
            _id = _id + 1;

            _projectTasks.Add(new ProjectTask(_id, createProjectTaskDTO.Description, 
                -1, projectId));

            SendDataToProject(projectId);

            return Ok();
        }

        /// <summary>
        /// Возвращает список всех задачь
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet("project/{projectId}/[controller]")]
        public IActionResult Get(int projectId)
        {
            var result = _projectTasks.Where(p => p.ProjectId == projectId).Select(p => new
            {
                p.TaskId,
                p.Description,
                p.EmployeeId,
                p.ProjectId
            });

            return Ok(result);
        }

        /// <summary>
        /// Возвращает список задачь проекта
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("project/{projectId}/[controller]/{id}")]
        public IActionResult GetById(int projectId, int id)
        {
            var result = _projectTasks.Where(p => p.ProjectId == projectId && p.TaskId == id).Select(p => new
            {
                p.TaskId,
                p.Description,
                p.EmployeeId,
                p.ProjectId
            });

            return Ok(result);
        }

        /// <summary>
        /// Обновляет задачу по id
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="id"></param>
        /// <param name="createProjectTaskDTO"></param>
        /// <returns></returns>
        [HttpPut("project/{projectId}/[controller]/{id}")]
        public IActionResult PutById(long projectId, long id, [FromBody] CreateProjectTaskDTO createProjectTaskDTO)
        {
            ProjectTask projectTask = _projectTasks.Where(p => p.TaskId == id).FirstOrDefault();
            _projectTasks.Remove(projectTask);

            SendDataToProject(projectId);

            _projectTasks.Add(new ProjectTask(id, createProjectTaskDTO.Description, projectTask.EmployeeId, projectId));

            return Ok();
        }

        /// <summary>
        /// Удаляет задачу по id
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="id"></param>
        /// <param name="createProjectTaskDTO"></param>
        /// <returns></returns>
        [HttpDelete("project/{projectId}/[controller]/{id}")]
        public IActionResult DeleteById(long projectId, long id, [FromBody] CreateProjectTaskDTO createProjectTaskDTO)
        {
            _projectTasks.Remove(_projectTasks.Where(p => p.TaskId == id).FirstOrDefault());

            SendDataToProject(projectId);

            return Ok();
        }

        /// <summary>
        /// Позволяет принимать обновленные данные из контроллера ProjectController для актуальности данных
        /// </summary>
        /// <param name="taskId"></param>
        public static void UpdatingFromProject(long taskId)
        {
            ProjectTask projectTask = _projectTasks.Where(p => p.TaskId == taskId).FirstOrDefault();

            if (_projectTasks.Contains(projectTask))
            {
                _projectTasks.Remove(projectTask);
            }
        }

        /// <summary>
        /// Позволяет отправлять обновленные данные в контроллер ProjectController для актуальности данных
        /// </summary>
        /// <param name="projectId"></param>
        private void SendDataToProject(long projectId)
        {
            CreateProjectDTO createProjectDTO = new CreateProjectDTO
            {
                TaskIds = _projectTasks.Where(p => p.ProjectId == projectId).Select(p => p.TaskId).ToList()
            };

            ProjectsController.UpdatingFromProjectTusk(createProjectDTO, projectId);
        }

        /// <summary>
        /// Позволяет принимать обновленные данные из контроллера EmployeesController для актуальности данных
        /// </summary>
        /// <param name="projectTaskId"></param>
        /// <param name="employeeId"></param>
        public static void UpdatingFromEmployee(long projectTaskId, long employeeId)
        {
            ProjectTask projectTask = _projectTasks.Where(p => p.TaskId == projectTaskId).FirstOrDefault();

            if (projectTask.EmployeeId == employeeId)
            {
                projectTask.EmployeeId = -1;
            }
            else
            {
                projectTask.EmployeeId = employeeId;
            }
        }
    }
}
