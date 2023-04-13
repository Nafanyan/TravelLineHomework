using Microsoft.AspNetCore.Mvc;
using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.API.Mappers.ProjectTaskMappers;
using ProjectsInTheCompany.Application;
using ProjectsInTheCompany.Application.Projects.ProjectsReceiving;
using ProjectsInTheCompany.Application.Projects.ProjectsUpdating;
using ProjectsInTheCompany.Application.ProjectTasks.Commands;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskCreating;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskDeleting;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskRecieving;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksUpdating;
using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;

namespace ProjectsInTheCompany.API.Controllers
{
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectReciever _projectReciever;
        private readonly IProjectUpdater _projectUpdater;
        private readonly IProjectTaskCreator _projectTaskCreator;
        private readonly IProjectTaskDeleter _projectTaskDeleter;
        private readonly IProjectTaskReciever _projectTaskReciever;
        private readonly IProjectTaskUpdater _projectTaskUpdater;
        private readonly IUnitOfWork _unitOfWork;


        public ProjectTaskController(
           IProjectReciever projectReciever,
           IProjectUpdater projectUpdater,
           IProjectTaskCreator projectTaskCreator,
           IProjectTaskDeleter projectTaskDeleter,
           IProjectTaskReciever projectTaskReciever,
           IProjectTaskUpdater projectTaskUpdater,
           IUnitOfWork unitOfWork)
        {
            _projectReciever = projectReciever;
            _projectUpdater = projectUpdater;
            _projectTaskCreator = projectTaskCreator;
            _projectTaskDeleter = projectTaskDeleter;
            _projectTaskReciever = projectTaskReciever;
            _projectTaskUpdater = projectTaskUpdater;
            _unitOfWork = unitOfWork;
        }


        [HttpGet("Project/{idProject}/[controller]")]
        public List<ProjectTaskDto> GetAll(int idProject)
        {
            IReadOnlyList<ProjectTask> projectTasks = _projectTaskReciever.GetAll();

            return projectTasks.Where(pt => pt.ProjectId == idProject)
                .Select(pt => pt.Map())
                .ToList();
        }

        [HttpGet("Project/{idProject}/[controller]/{id}")]
        public ProjectTaskDto GetById(int idProject, int id)
        {

            if (ValidatePath(idProject, id))
            {
                return _projectTaskReciever.GetById(id).Map();
            }

            return new ProjectTaskDto();

        }

        [HttpPost("Project/{idProject}/[controller]")]
        public void Add(int idProject, [FromBody] AddProjectTaskCommandDto addProjectTaskCommandDto)
        {
            if (ValidatePath(idProject))
            {
                AddProjectTaskCommand addProjectTaskCommand = addProjectTaskCommandDto.Map(_projectReciever.GetById(idProject));
                _projectTaskCreator.Create(addProjectTaskCommand);

                _unitOfWork.Commit();
            }

        }

        [HttpDelete("Project/{idProject}/[controller]/{id}")]
        public void DeleteById(int idProject, int id)
        {

            if (ValidatePath(idProject, id))
            {
                _projectTaskDeleter.Delete(id);
                _unitOfWork.Commit();
            }

        }

        [HttpPut("Project/{idProject}/[controller]/{id}")]
        public void Update(int idProject, int id, [FromBody] AddProjectTaskCommandDto addProjectTaskCommandDto)
        {

            if (ValidatePath(idProject, id))
            {
                UpdateProjectTaskCommandDto updateProjectTaskCommandDto = new UpdateProjectTaskCommandDto
                {
                    Id = id,
                    Description = addProjectTaskCommandDto.Description,
                };
                _projectTaskUpdater.Update(updateProjectTaskCommandDto.Map());
                _unitOfWork.Commit();
            }


        }
        private bool ValidatePath(int idProject, int id = -1)
        {
            Project? project = _projectReciever.GetById(idProject);
            if (project == null)
            {
                return false;
            }

            if (id != -1)
            {
                ProjectTask? projectTask = _projectTaskReciever.GetById(id);

                if (projectTask == null)
                {
                    return false;
                }

                if (_projectTaskReciever.GetById(id).ProjectId != idProject)
                {
                    return false;
                }
            }


            return true;
        }
    }
}
