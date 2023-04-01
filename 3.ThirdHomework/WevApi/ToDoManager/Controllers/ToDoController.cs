using Microsoft.AspNetCore.Mvc;
using ToDoManager.Domain;

namespace ToDoManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private static readonly List<ToDo> _toDos = new();

        /// <summary>
        /// Возвращает все ToDo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _toDos.Select(t => new { t.Id, t.Title, plannedDay = t.PlannedDay.ToString("yyy-MM-dd hh:mm:ss") });
            return Ok(result);
        }

        /// <summary>
        /// Возвращает ToDo по id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Создает ToDo
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] CreateToDoDto createDto)
        {
            int id = _toDos.Count + 1;
            ToDo toDo = new ToDo(id, createDto.Title);

            _toDos.Add(toDo);

            return Ok();
        }
    }
}
