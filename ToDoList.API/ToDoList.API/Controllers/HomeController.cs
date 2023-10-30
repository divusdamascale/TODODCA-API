using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("test")]
    public class HomeController : Controller
    {

        private readonly TodolistdcaContext _context;

        public HomeController(TodolistdcaContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult testConnection()
        {
            try
            {
                // Încercă să deschizi o conexiune la baza de date
                _context.Database.OpenConnection();
                return Ok("Conexiunea la baza de date este funcțională.");
            }
            catch (Exception ex)
            {
                return BadRequest("Eroare la conectare: " + ex.Message);
            }
        }
    }
}
