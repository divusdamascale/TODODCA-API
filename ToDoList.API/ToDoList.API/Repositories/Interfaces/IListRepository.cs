using Microsoft.EntityFrameworkCore;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Repositories.Interfaces
{
    public interface IListRepository
    {
        Task<List<List>> getListsByUserId(int userId);

        Task<List> CreateList(List list);

        Task<List> DeleteList(int id);
    }
}
