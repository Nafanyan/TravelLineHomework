using Microsoft.AspNetCore.Mvc;
using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.API.Mappers.ProjectTaskMappers;
using ProjectsInTheCompany.Application;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskCreating;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskDeleting;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskRecieving;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksCreating;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksUpdating;
using ProjectsInTheCompany.Domain.Exceptions.ProjectTaskExceprions;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.API.Controllers
{
    [ApiController]
    [Route("Project")]
    public class ProjectTasksController : ControllerBase
    {
        private readonly IProjectTaskCreator _projectTaskCreator;
        private readonly IProjectTaskDeleter _projectTaskDeleter;
        private readonly IProjectTaskReciever _projectTaskReciever;
        private readonly IProjectTaskUpdater _projectTaskUpdater;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectTasksController(
           IProjectTaskCreator projectTaskCreator,
           IProjectTaskDeleter projectTaskDeleter,
           IProjectTaskReciever projectTaskReciever,
           IProjectTaskUpdater projectTaskUpdater,
           IUnitOfWork unitOfWork)
        {
            _projectTaskCreator = projectTaskCreator;
            _projectTaskDeleter = projectTaskDeleter;
            _projectTaskReciever = projectTaskReciever;
            _projectTaskUpdater = projectTaskUpdater;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_projectTaskReciever.GetAll()
                .Select(p => p.Map())
                .ToList());
        }

        [HttpGet("{projectId}/[controller]")]
        public IActionResult GetAllInProject(int projectId)
        {
            IReadOnlyList<ProjectTask> projectTasks = _projectTaskReciever.GetAll();

            return Ok(projectTasks.Where(pt => pt.ProjectId == projectId)
                .Select(pt => pt.Map())
                .ToList());
        }

        [HttpGet("{projectId}/[controller]/{id}")]
        public IActionResult GetById(int projectId, int id)
        {
            try
            {
                return Ok(_projectTaskReciever.GetById(id).Map());
            }
            catch (ProjectTaskException pt)
            {
                return Ok($"Error when trying to get information about the project task: {pt.Message}");
            }
        }

        [HttpPost("{projectId}/[controller]")]
        public IActionResult Add(int projectId, [FromBody] ProjectTaskCommandDto projectTaskCommandDto)
        {
            try
            {
                AddProjectTaskCommand addProjectTaskCommand = projectTaskCommandDto.Map(projectId);
                _projectTaskCreator.Create(addProjectTaskCommand);

                _unitOfWork.Commit();
                return Ok($"Project task added");
            }
            catch (ProjectTaskException pt)
            {
                return Ok($"Error when trying to add the project task: {pt.Message}");
            }
        }

        [HttpDelete("{projectId}/[controller]/{id}")]
        public IActionResult DeleteById(int projectId, int id)
        {
            try
            {
                _projectTaskDeleter.Delete(id);
                _unitOfWork.Commit();
                return Ok($"Project task deleted");
            }
            catch (ProjectTaskException pt)
            {
                return Ok($"Error when trying to delete a project task: {pt.Message}");
            }
        }

        [HttpPut("{projectId}/[controller]/{id}")]
        public IActionResult Update(int projectId, int id, [FromBody] ProjectTaskCommandDto addProjectTaskCommandDto)
        {
            try
            {
                _projectTaskUpdater.Update(addProjectTaskCommandDto.Map(id, projectId));
                _unitOfWork.Commit();
                return Ok($"Project task updated");
            }
            catch (ProjectTaskException pt)
            {
                return Ok($"Error when trying to update project task information: {pt.Message}");
            }
        }
    }
}
