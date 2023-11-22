using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Domain.Entity;
using ToDoList.API.Views.DTOs;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterDTO> RegisterAsync(RegisterDTO register);
        Task<LoggedUser> LoginAsync(LoginDTO login);
    }
}
