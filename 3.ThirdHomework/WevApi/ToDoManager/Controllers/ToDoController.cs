using Microsoft.AspNetCore.Mvc;
using ToDoManager.Domain;
using ToDoManager.Dto;

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

        /// <summary>
        /// Возвращает ToDo по id 
        /// </summary>
        /// <param "id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _toDos.Where(t => t.Id == id).FirstOrDefault();
            return Ok(result);
        }

        /// <summary>
        /// Обновляет значение ToDo по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutById(int id, [FromBody] CreateToDoDto createDto)
        {
            var result = _toDos.Remove(_toDos.Where(t => t.Id == id).FirstOrDefault());
            _toDos.Add(new ToDo(id, createDto.Title));
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var result = _toDos.Remove(_toDos.Where(t => t.Id == id).FirstOrDefault());
            return Ok();
        }
    }
}
