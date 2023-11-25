using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Domain.Entity;
using ToDoList.API.Services.Interfaces;
using ToDoList.API.Views.DTOs;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<JwtResult> Login(LoginDTO login)
        {
            var result = await _authService.LoginAsync(login);

            if (result != null)
            {
                return result; // Autentificare reușită
            }

            return null; // Autentificare eșuată
        }

    [HttpPost("register")]

    public async Task<IActionResult> Register(RegisterDTO register)
    {
        if (ModelState.IsValid)
        {
            var userResult = await _authService.RegisterAsync(register);
            return Ok(userResult);
        }

        return BadRequest(ModelState);
    }

    }
      
}

