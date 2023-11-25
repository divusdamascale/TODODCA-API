using ToDoList.API.Domain.DTOs;

namespace ToDoList.API.Services.Interfaces
{
    public interface IListService
    {
        Task<List<ListDTO>> GetListsByUserID(int userId);
    }
}
