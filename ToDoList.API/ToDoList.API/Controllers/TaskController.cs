using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Services.Interfaces;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("task")]
    public class TaskController : Controller
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }
        

        [Authorize]
        [HttpGet("getAllTask")]
        public async Task<IActionResult> GetAllTask()
        {
            var list = await _service.GetAllTasks();

            if(list.Any())
            {
                return Ok(list);
            }
            return NotFound();

        }

        [Authorize]
        [HttpGet("GetTaskById/{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute] int id)
        {
            var task = await _service.GetTaskById(id);

            if(task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("GetTaskByListId/{id}")]
        public async Task<IActionResult> GetTaskByListId([FromRoute] int id)
        {
            var list  = await _service.GetTasksByListId(id);

            if(list.Any())
            {
                return Ok(list);
            }
            
            return NotFound();
        }

        [Authorize]
        [HttpPost("CreateTask")]
        public async Task<Views.Models.Task> CreateTask([FromBody] TaskToAddDTO task)
        {
            try
            {
                var taskAdded = await _service.CreateTask(task);
                if(taskAdded.TaskName is null) throw new Exception("The task could not been created");
                return taskAdded;
            }
            catch(Exception)
            {
                return null;
            }
        }

        [Authorize]
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskToUpdateDTO task)
        {
            var task1 = await _service.UpdateTask(task);

            if(task != null)
            {
                return Ok(task);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            var delete = await _service.DeleteTask(id);

            if(delete != null)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPut("ChangeState/{id}")]
        public async Task<IActionResult> ChangeState([FromRoute] int id,bool state)
        {
            var task = await _service.ChangeState(id,state);

            if(task)
            {
                return Ok(task);
            }

            return BadRequest();
        }


    }
}
