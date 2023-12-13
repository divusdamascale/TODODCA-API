using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Services.Interfaces;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("list")]
    public class ListsController:Controller
    {
        private readonly IListService _service;

        public ListsController(IListService service)
        {
            _service = service;
        }


        [Authorize]
        [HttpGet("getByUserId/{id}")]
        public async Task<List<ListDTO>> GetByUserId([FromRoute]int id)
        {
            var result = await _service.GetListsByUserID(id);
            return result;
        }

        [Authorize]
        [HttpPost("CreateList")]
        public async Task<IActionResult> Create([FromBody]ListToAddDTO list)
        {
            var result = await _service.CreateList(list);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("DeleteList/{id}")]

        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var result = await _service.DeleteList(id);
            return Ok(result);
        }



    }
}
