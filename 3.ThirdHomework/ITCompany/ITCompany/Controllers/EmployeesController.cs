using ITCompany.Domain;
using ITCompany.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ITCompany.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<Employee> _employees = new();
        private static long _id = 0;


        /// <summary>
        /// Создает нового работника
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="createEmployeeDTO"></param>
        /// <returns></returns>
        [HttpPost("project/{projectId}/ProjectTasks/{taskId}/[controller]")]
        public IActionResult Create(long taskId, [FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            _id = _id + 1;
            if(_employees.Where(e => e.ProjectTaskId == taskId).FirstOrDefault() != null)
            {
                return Ok("Этой задачей уже занят один человек");
            }

            Employee employee = new Employee(_id, createEmployeeDTO.EmployeeName, createEmployeeDTO.EmployeeSurname,
                createEmployeeDTO.EmployeePost, taskId);
            SendDataToProjectTasks(taskId, _id);
            _employees.Add(employee);

            return Ok();
        }

        /// <summary>
        /// Возвращает работающего над задачей
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("project/{projectId}/ProjectTasks/{taskId}/[controller]")]
        public IActionResult Get(long taskId)
        {
            var result = _employees.Where(e => e.ProjectTaskId == taskId).Select(e => new
            {
                e.EmployeeId,
                e.EmployeeName,
                e.EmployeeSurname,
                e.EmployeePost,
                e.ProjectTaskId
            });
            return Ok(result);
        }

        /// <summary>
        /// Обновляет данные о работнике
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="createEmployeeDTO"></param>
        /// <returns></returns>
        [HttpPut("project/{projectId}/ProjectTasks/{taskId}/[controller]")]
        public IActionResult Put(long taskId, CreateEmployeeDTO createEmployeeDTO)
        {
            Employee employee = _employees.Where(e => e.ProjectTaskId == taskId).FirstOrDefault();
            _employees.Remove(employee);

            _employees.Add(new Employee(employee.EmployeeId, createEmployeeDTO.EmployeeName, createEmployeeDTO.EmployeeSurname,
                createEmployeeDTO.EmployeePost, taskId));
            return Ok();
        }

        /// <summary>
        /// Удаляет работника по id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpDelete("project/{projectId}/ProjectTasks/{taskId}/[controller]")]
        public IActionResult Delete(long taskId)
        {
            Employee employee = _employees.Where(e => e.ProjectTaskId == taskId).FirstOrDefault();
            SendDataToProjectTasks(taskId, employee.EmployeeId);
            _employees.Remove(employee);
            
            return Ok();
        }

        /// <summary>
        /// Позволяет отправлять обновленные данные в контроллер ProjectTasksController для актуальности данных
        /// </summary>
        /// <param name="projectTaskId"></param>
        /// <param name="employeeId"></param>
        private void SendDataToProjectTasks(long projectTaskId, long employeeId)
        {
            ProjectTasksController.UpdatingFromEmployee(projectTaskId, employeeId);
        }


    }
}
