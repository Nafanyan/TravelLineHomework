using Microsoft.AspNetCore.Mvc;
using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.API.Mappers.ProjectMappers;
using ProjectsInTheCompany.API.Mappers.ProjectTaskMappers;
using ProjectsInTheCompany.Application.Projects.ProjectsReceiving;
using ProjectsInTheCompany.Application.ProjectTasks.Commands;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskCreating;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskDeleting;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskRecieving;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTasksUpdating;
using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;
using ProjectsInTheCompany.Infrastructure.Foundation;

namespace ProjectsInTheCompany.API.Controllers
{
    [ApiController]

    public class ProjectTaskController
    {
        private readonly ProjectTaskCreator _projectTaskCreator;
        private readonly ProjectTaskDeleter _projectTaskDeleter;
        private readonly ProjectTaskReciever _projectTaskReciever;
        private readonly ProjectTaskUpdater _projectTaskUpdater;
        private readonly UnitOfWork _unitOfWork;

         public ProjectTaskController(
            ProjectTaskCreator projectTaskCreator,
            ProjectTaskDeleter projectTaskDeleter,
            ProjectTaskReciever projectTaskReciever,
            ProjectTaskUpdater projectTaskUpdater,
            UnitOfWork unitOfWork)
        {
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

        //[HttpGet("Project/{idProject}/[controller]/{id}")]
        //public ProjectTaskDto GetById(int idProject, int id)
        //{
        //    Project project = _projectReciever.GetById(idProject);
        //    return project.ProjectTasks.Where(pt => pt.Id == id)
        //        .SingleOrDefault().Map();
        //}

        //[HttpPost("Project/{idProject}/[controller]")]
        //public void Add(int idProject, [FromBody] AddProjectTaskCommandDto addProjectTaskCommandDto)
        //{
        //    AddProjectTaskCommand addProjectTaskCommand = addProjectTaskCommandDto.Map(_projectReciever.GetById(idProject));
        //    _projectTaskCreator.Create(addProjectTaskCommand);
        //    _unitOfWork.Commit();
        //}

        //[HttpDelete("Project/{idProject}/[controller]/{id}")]
        //public void DeleteById(int idProject, int id)
        //{
        //    Project project = _projectReciever.GetById(idProject);
        //    if (project.ProjectTasks.Where(pt => pt.Id == id).SingleOrDefault() != null)
        //    {
        //        _projectTaskDeleter.Delete(id);
        //        _unitOfWork.Commit();
        //    }
        //}

        //[HttpPut("Project/{idProject}/[controller]/{id}")]
        //public void Update(int idProject, int id, [FromBody] AddProjectTaskCommandDto addProjectTaskCommandDto)
        //{
        //    Project project = _projectReciever.GetById(idProject);

        //    if (project.ProjectTasks.Where(pt => pt.Id == id).SingleOrDefault() != null)
        //    {
        //        UpdateProjectTaskCommandDto updateProjectTaskCommandDto = new UpdateProjectTaskCommandDto
        //        {
        //            Id = id,
        //            Description = addProjectTaskCommandDto.Description,
        //            Project = project
        //        };
        //        _projectTaskUpdater.Update(updateProjectTaskCommandDto.Map());
        //        _unitOfWork.Commit();
        //    }

        //}
    }
}
