using Microsoft.AspNetCore.Mvc;
using ProjectsInTheCompany.API.Dtos.ProjectsDtos;
using ProjectsInTheCompany.API.Mappers.ProjectMappers;
using ProjectsInTheCompany.Application;
using ProjectsInTheCompany.Application.Projects.ProjectsCreating;
using ProjectsInTheCompany.Application.Projects.ProjectsDeleting;
using ProjectsInTheCompany.Application.Projects.ProjectsReceiving;
using ProjectsInTheCompany.Application.Projects.ProjectsUpdating;
using ProjectsInTheCompany.Domain.Exceptions.ProjectExceptions;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectCreator _projectCreator;
        private readonly IProjectDeleter _projectDeleter;
        private readonly IProjectReciever _projectReciever;
        private readonly IProjectUpdater _projectUpdater;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(
            IProjectCreator projectCreator,
            IProjectDeleter projectDeleter,
            IProjectReciever projectReciever,
            IProjectUpdater projectUpdater,
            IUnitOfWork unitOfWork)
        {
            _projectCreator = projectCreator;
            _projectDeleter = projectDeleter;
            _projectReciever = projectReciever;
            _projectUpdater = projectUpdater;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IReadOnlyList<Project> projects = _projectReciever.GetAll();

            return Ok(projects.Select(p => p.Map())
                .ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Project project = _projectReciever.GetById(id);
                return Ok(project.Map());
            }
            catch (ProjectException p)
            {
                return Ok($"Error when trying to get information about the project: {p.Message}");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProjectCommandDto projectCommandDto)
        {
            _projectCreator.Create(projectCommandDto.Map());
            _unitOfWork.Commit();
            return Ok("Project added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {

            try
            {
                _projectDeleter.Delete(id);
                _unitOfWork.Commit();
                return Ok("Project deleted");
            }
            catch (ProjectException p)
            {
                return Ok($"Error when trying to delete a project: {p.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProjectCommandDto projectCommandDto)
        {

            try
            {
                _projectUpdater.Update(projectCommandDto.Map(id));
                _unitOfWork.Commit();
                return Ok("Project updated");
            }
            catch (ProjectException p)
            {
                return Ok($"Error when trying to update project information: {p.Message}");
            }
        }
    }
}
