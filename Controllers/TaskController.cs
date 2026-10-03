using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Services;
using StudentApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace StudentApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTaskItems()
        {
            var Tasks = await _taskService.GetTaskItemsAsync();

            return Ok(Tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskItem(int id)
        {
            var task = await _taskService.GetTaskItemAsync(id);

            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskItem(TaskItem task)
        {
            await _taskService.AddTaskAsync(task);

            return CreatedAtAction(
                nameof(GetTaskItem),
                new { id = task.Id },
                task
                );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskItem(int id, TaskItem task)
        {
            var taskToUpdate = await _taskService.UpdateTaskAsync(id, task);

            if(taskToUpdate == null)
            {
                return NotFound();
            }

            return Ok(taskToUpdate);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var taskToDelete = await _taskService.DeleteTaskAsync(id);
            if (!taskToDelete)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}
