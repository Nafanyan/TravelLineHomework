//using ITCompany.Domain;
//using ITCompany.DTO;
//using Microsoft.AspNetCore.Mvc;

//namespace ITCompany.Controllers
//{
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        private long _id = 0;
//        private static readonly List<Employee> _employees = new();

//        /// <summary>
//        /// Создает объект рабочего
//        /// </summary>
//        /// <param name="createEmployeeDTO"></param>
//        /// <returns></returns>
//        [HttpPost("[controller]")]
//        public IActionResult Create([FromBody] CreateEmployeeDTO createEmployeeDTO)
//        {
//            _id += 1;
//            Employee employee = new Employee(_id, createEmployeeDTO.EmployeeName, createEmployeeDTO.EmployeeSurname, createEmployeeDTO.EmployeePost,
//                createEmployeeDTO.EmployeeDepartamentId);

//            SwapDepartament(createEmployeeDTO.EmployeeDepartamentId, employee);

//            _employees.Add(employee);
//            return Ok();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet("[controller]")]
//        public IActionResult Get()
//        {
//            var result = _employees.Select(e => new { e.EmployeeId, e.EmployeeName, e.EmployeeSurname, e.EmployeePost, e.EmployeeDepartamentId });
//            return Ok(result);
//        }

//        private void SwapDepartament(long newDepartamentId, Employee employee)
//        {
//            ProjectTasksController departamentController = new ProjectTasksController();

//            // Удаление рабочего с прошлого отдела
//            if (employee.EmployeeDepartamentId != null)
//            {
//                var oldDepartament = ProjectTasksController.GetDepartaments().Where(d => d.DepartamentId == employee.EmployeeDepartamentId).FirstOrDefault();
//                oldDepartament.DepartamentTeamId.Remove(employee.EmployeeId);

//                CreateProjectTaskDTO createDepartamentDTO = new()
//                {
//                    DepartamentName = oldDepartament.DepartamentName,
//                    DepartamentTeamId = oldDepartament.DepartamentTeamId,
//                    DepartamentProjectsId = oldDepartament.DepartamentProjectsId
//                };

//                departamentController.PutById(oldDepartament.DepartamentId, createDepartamentDTO);
//            }

//            // Запись рабочего в новый отдел
//            if (ProjectTasksController.GetDepartaments().Where(d => d.DepartamentId == newDepartamentId).FirstOrDefault() != null)
//            {
//                var newDepartament = ProjectTasksController.GetDepartaments().Where(d => d.DepartamentId == newDepartamentId).FirstOrDefault();
//                newDepartament.DepartamentTeamId.Add(employee.EmployeeId);

//                CreateProjectTaskDTO createDepartamentDTO = new()
//                {
//                    DepartamentName = newDepartament.DepartamentName,
//                    DepartamentTeamId = newDepartament.DepartamentTeamId,
//                    DepartamentProjectsId = newDepartament.DepartamentProjectsId
//                };

//                departamentController.PutById(newDepartament.DepartamentId, createDepartamentDTO);
//            }

//        }
//    }
//}
