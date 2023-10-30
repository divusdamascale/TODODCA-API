using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Views.DTOs;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Controllers
{
        [ApiController]
        [Route("auth")]
    public class AuthController : Controller
    {

        [HttpGet("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            return Ok(login);
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(User register)
        {
            return Ok(register);
        }
      
    }
}
