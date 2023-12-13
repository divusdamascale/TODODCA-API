using ToDoList.API.Domain.DTOs;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Services.Interfaces
{
    public interface IListService
    {
        Task<List<ListDTO>> GetListsByUserID(int userId);

        Task<List> CreateList(ListToAddDTO list);

        Task<List> DeleteList(int id);


    }
}
