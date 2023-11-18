using Microsoft.AspNetCore.Mvc;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Views.DTOs;

namespace ToDoList.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterDTO> RegisterAsync(RegisterDTO register);
        Task<string> LoginAsync(LoginDTO login);
    }
}
