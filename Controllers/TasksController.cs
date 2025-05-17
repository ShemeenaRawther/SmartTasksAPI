using Microsoft.AspNetCore.Mvc;
using SmartTasksAPI.DTOs;
using SmartTasksAPI.Services;

namespace SmartTasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks(
        [FromQuery] string? priority,
        [FromQuery] DateTime? dueDate,
        [FromQuery] string? status)
        {
            var tasks = await _taskService.GetFilteredTasksAsync(priority, dueDate, status);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskDto dto)
        {
            var newTask = await _taskService.CreateTaskAsync(dto);
            return Ok(newTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskDto dto)
        {
            var success = await _taskService.UpdateTaskAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _taskService.DeleteTaskAsync(id);
            return success ? NoContent() : NotFound();
        }

    }
}
