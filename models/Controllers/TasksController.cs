using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        static List<TaskItem> tasks = new List<TaskItem>();
        static int nextId = 1;

        [HttpGet]
        public IActionResult Get() => Ok(tasks);

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            task.Id = nextId++;
            tasks.Add(task);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task == null) return NotFound();

            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task == null) return NotFound();

            tasks.Remove(task);
            return Ok();
        }
    }
}
