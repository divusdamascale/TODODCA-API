using ToDoList.API.Domain.DTOs;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Views.Models.Task>> GetAllTasks();

        Task<Views.Models.Task> GetTaskById(int id);

        Task<IEnumerable<Views.Models.Task>> GetTasksByListId(int listId);

        Task<Views.Models.Task> CreateTask(Views.Models.Task task);

        Task<Views.Models.Task> UpdateTask(Views.Models.Task task);

        Task<Views.Models.Task> DeleteTask(Views.Models.Task task);

    }
}
