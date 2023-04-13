using Microsoft.AspNetCore.Mvc;
using ProjectsInTheCompany.API.Dtos.EmployeeDtos;
using ProjectsInTheCompany.API.Dtos.ProjectTaskDtos;
using ProjectsInTheCompany.API.Mappers.EmployeeMappers;
using ProjectsInTheCompany.Application;
using ProjectsInTheCompany.Application.Employees.Commands;
using ProjectsInTheCompany.Application.Employees.EmployeesCreating;
using ProjectsInTheCompany.Application.Employees.EmployeesDeleting;
using ProjectsInTheCompany.Application.Employees.EmployeesReceiving;
using ProjectsInTheCompany.Application.Employees.EmployeesUpdating;
using ProjectsInTheCompany.Application.Projects.ProjectsReceiving;
using ProjectsInTheCompany.Application.ProjectTasks.ProjectTaskRecieving;
using ProjectsInTheCompany.Domain.Employees;
using ProjectsInTheCompany.Domain.Projects;
using ProjectsInTheCompany.Domain.ProjectTasks;
using System.Linq;

namespace ProjectsInTheCompany.API.Controllers
{
    [ApiController]
    public class EmployeeController
    {
        private readonly IProjectReciever _projectReciever;
        private readonly IProjectTaskReciever _projectTaskReciever;
        private readonly IEmployeeCreator _employeeCreator;
        private readonly IEmployeeDeletor _employeeDeletor;
        private readonly IEmployeeReciever _employeeReciever;
        private readonly IEmployeeUpdater _employeeUpdater;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(
            IProjectReciever projectReciever,
            IProjectTaskReciever projectTaskReciever,
            IEmployeeCreator employeeCreator,
            IEmployeeDeletor employeeDeletor,
            IEmployeeReciever employeeReciever,
            IEmployeeUpdater employeeUpdater,
            IUnitOfWork unitOfWork
            )
        {
            _projectReciever = projectReciever;
            _projectTaskReciever = projectTaskReciever;
            _employeeCreator = employeeCreator;
            _employeeDeletor = employeeDeletor;
            _employeeReciever = employeeReciever;
            _employeeUpdater = employeeUpdater;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Project/{idProject}/ProjectTask/{idProjectTask}/[controller]")]
        public EmployeeDto Get(int idProject, int idProjectTask)
        {
            
            if (ValidatePath(idProject, idProjectTask))
            {
                return _employeeReciever.GetAll().Where(e => e.ProjectTaskId == idProjectTask)
                    .SingleOrDefault()
                    .Map();
        }

            return new EmployeeDto();
        }

        [HttpPost("Project/{idProject}/ProjectTask/{idProjectTask}/[controller]")]
        public void Add(int idProject, int idProjectTask, [FromBody] AddEmployeeCommandDto addEmployeeCommandDto)
        {
            if (ValidatePath(idProject, idProjectTask))
            {
                AddEmployeeCommand addEmployeeCommand = addEmployeeCommandDto.Map(_projectTaskReciever.GetById(idProjectTask));

                _employeeCreator.Create(addEmployeeCommand);
                _unitOfWork.Commit();
            }

        }

        [HttpDelete("Project/{idProject}/ProjectTask/{idProjectTask}/[controller]/{id}")]
        public void Delete(int idProject, int idProjectTask, int id)
        {
            if (ValidatePath(idProject, idProjectTask, id))
            {
                _employeeDeletor.Delete(id);
                _unitOfWork.Commit();
            }
        }

        [HttpPut("Project/{idProject}/ProjectTask/{idProjectTask}/[controller]/{id}")]
        public void Update(int idProject, int idProjectTask, int id, [FromBody] AddEmployeeCommandDto addEmployeeCommandDto)
        {
            if (ValidatePath(idProject, idProjectTask, id))
            {
                UpdateEmployeeCommandDto updateEmployeeCommandDto = new UpdateEmployeeCommandDto
                {
                    Id = id,
                    Name = addEmployeeCommandDto.Name,
                    Surname = addEmployeeCommandDto.Surname
                };
                _employeeUpdater.Update(updateEmployeeCommandDto.Map());
            }
        }
        private bool ValidatePath(int idProject, int idProjectTask, int id = -1)
        {
            ProjectTask? projectTask = _projectTaskReciever.GetById(idProjectTask);
           

            if (projectTask == null)
            {
                return false;
            }

            Project? project = _projectReciever.GetById(projectTask.ProjectId);

            if (project == null)
            {
                return false;
            }

            if (projectTask.ProjectId != idProject)
            {
                return false;
            }

            if (id != -1)
            {
                Employee? employee = _employeeReciever.GetById(id);

                if (employee == null)
                {
                    return false;
                }

                if (employee.ProjectTaskId != idProjectTask)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
