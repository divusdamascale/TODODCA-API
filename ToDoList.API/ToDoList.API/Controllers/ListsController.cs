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


    }
}
