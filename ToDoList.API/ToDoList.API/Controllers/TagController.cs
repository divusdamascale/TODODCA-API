using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Services.Interfaces;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Controllers
{

    [ApiController]
    [Route("tag")]
    public class TagController : Controller
    {
        private readonly ITagService _service;
        
        public TagController(ITagService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("getByUserId/{id}")]
        public async Task<List<Tag>> GetByUserId([FromRoute]int id)
        {
            var result = await _service.GetTagsByUserIdAsync(id);
            return (List<Tag>)result;
        }

        [Authorize]
        [HttpGet("getByTaskId/{id}")]
        public async Task<List<Tag>> GetByTaskId([FromRoute]int id)
        {
            var result = await _service.GetTagsByTaskIdAsync(id);
            return (List<Tag>)result;
        }

        [Authorize]
        [HttpPost("CreateTag")]
        public async Task<IActionResult> Create([FromBody]TagToAddDTO tag)
        {
            var result = await _service.CreateTagAsync(tag);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("DeleteTag/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var result = await _service.DeleteTagAsync(id);
            return Ok(result);
        }
        [Authorize]
        [HttpPut("UpdateTag")]
        public async Task<IActionResult> Update([FromBody]TagToUpdateDTO tag)
        {
            var result = await _service.UpdateTagAsync(tag);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetTagById/{id}")]
        public async Task<Tag> GetTagById([FromRoute]int id)
        {
            var result = await _service.GetTagByIdAsync(id);
            return result;
        }
        
        
    }
}
