using Microsoft.AspNetCore.Mvc;
using ProjectsInTheCompany.API.Dtos.ProjectsDtos;
using ProjectsInTheCompany.API.Mappers.ProjectMappers;
using ProjectsInTheCompany.Application;
using ProjectsInTheCompany.Application.Projects.ProjectsCreating;
using ProjectsInTheCompany.Application.Projects.ProjectsDeleting;
using ProjectsInTheCompany.Application.Projects.ProjectsReceiving;
using ProjectsInTheCompany.Application.Projects.ProjectsUpdating;
using ProjectsInTheCompany.Domain.Projects;

namespace ProjectsInTheCompany.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController
    {
        private readonly IProjectCreator _projectCreator;
        private readonly IProjectDeleter _projectDeleter;
        private readonly IProjectReciever _projectReciever;
        private readonly IProjectUpdater _projectUpdater;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(
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
        public List<ProjectDto> GetAll()
        {
            IReadOnlyList<Project> projects = _projectReciever.GetAll();
            return projects.Select(p => p.Map())
                .ToList();
        }

        [HttpGet("{id}")]
        public ProjectDto GetById(int id)
        {
            Project project = _projectReciever.GetById(id);
            return project.Map();
        }

        [HttpPost]
        public void Add([FromBody] AddProjectCommandDto addProjectCommandDto)
        {
            _projectCreator.Create(addProjectCommandDto.Map());
            _unitOfWork.Commit();
        }

        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            _projectDeleter.Delete(id);
            _unitOfWork.Commit();
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] AddProjectCommandDto addProjectCommandDto)
        {
            UpdateProjectCommandDto updateProjectCommandDto = new UpdateProjectCommandDto
            {
                Id = id,
                Title = addProjectCommandDto.Title,
                Description = addProjectCommandDto.Description
            };
            _projectUpdater.Update(updateProjectCommandDto.Map());
            _unitOfWork.Commit();
        }
    }
}
