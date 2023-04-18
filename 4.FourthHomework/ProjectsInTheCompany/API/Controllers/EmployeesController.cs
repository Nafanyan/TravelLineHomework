using Microsoft.AspNetCore.Mvc;
using ProjectsInTheCompany.API.Dtos.EmployeeDtos;
using ProjectsInTheCompany.API.Mappers.EmployeeMappers;
using ProjectsInTheCompany.API.Mappers.ProjectTaskMappers;
using ProjectsInTheCompany.Application;
using ProjectsInTheCompany.Application.Employees.EmployeesCreating;
using ProjectsInTheCompany.Application.Employees.EmployeesDeleting;
using ProjectsInTheCompany.Application.Employees.EmployeesReceiving;
using ProjectsInTheCompany.Application.Employees.EmployeesUpdating;
using ProjectsInTheCompany.Domain.Exceptions.EmployeeExceprions;

namespace ProjectsInTheCompany.API.Controllers
{
    [ApiController]
    [Route("Projects")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeCreator _employeeCreator;
        private readonly IEmployeeDeletor _employeeDeletor;
        private readonly IEmployeeReciever _employeeReciever;
        private readonly IEmployeeUpdater _employeeUpdater;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(
            IEmployeeCreator employeeCreator,
            IEmployeeDeletor employeeDeletor,
            IEmployeeReciever employeeReciever,
            IEmployeeUpdater employeeUpdater,
            IUnitOfWork unitOfWork
            )
        {
            _employeeCreator = employeeCreator;
            _employeeDeletor = employeeDeletor;
            _employeeReciever = employeeReciever;
            _employeeUpdater = employeeUpdater;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{idProject}/ProjectTasks/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_employeeReciever.GetAll()
                .Select(p => p.Map())
                .ToList());
        }

        [HttpGet("{idProject}/ProjectTasks/{idProjectTask}/[controller]/{id}")]
        public IActionResult GetById(int idProject, int idProjectTask, int id)
        {
            try
            {
                return Ok(_employeeReciever.GetById(id).Map());
            }
            catch (EmployeeException e)
            {
                return Ok($"Error when trying to get information about the employee: {e.Message}");
            }

        }

        [HttpPost("Projects/{idProject}/ProjectTasks/{idProjectTask}/[controller]")]
        public IActionResult Add(int idProject, int idProjectTask, [FromBody] EmployeeCommandDto employeeCommandDto)
        {
            try
            {
                AddEmployeeCommand addEmployeeCommand = employeeCommandDto.Map(idProjectTask);
                _employeeCreator.Create(addEmployeeCommand);
                _unitOfWork.Commit();

                return Ok("Employee added");
            }
            catch (EmployeeException e)
            {
                return Ok($"Error when trying to add the employee: {e.Message}");
            }
        }

        [HttpDelete("Projects/{idProject}/ProjectTasks/{idProjectTask}/[controller]/{id}")]
        public IActionResult Delete(int idProject, int idProjectTask, int id)
        {
            try
            {
                _employeeDeletor.Delete(id);
                _unitOfWork.Commit();

                return Ok("Employee deleted");
            }
            catch (EmployeeException e)
            {
                return Ok($"Error when trying to delete a employee: {e.Message}");
            }
        }

        [HttpPut("Projects/{idProject}/ProjectTasks/{idProjectTask}/[controller]/{id}")]
        public IActionResult Update(int idProject, int idProjectTask, int id, [FromBody] EmployeeCommandDto employeeCommandDto)
        {
            try
            {
                _employeeUpdater.Update(employeeCommandDto.Map(id, idProjectTask));

                return Ok("Employee updated");
            }
            catch (EmployeeException e)
            {
                return Ok($"Error when trying to delete a employee: {e.Message}");
            }
        }
    }
}
