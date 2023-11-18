using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("List")]
    public class ListsController:Controller
    {


        [Authorize]
        [HttpGet("getById/{id}")]
        public string GetById([FromRoute]int id)
        {
            return id.ToString();
        }


    }
}
