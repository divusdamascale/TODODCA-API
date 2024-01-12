using ToDoList.API.Domain.DTOs;

namespace ToDoList.API.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Views.Models.Task>> GetAllTasks();

        Task<Views.Models.Task> GetTaskById(int id);

        Task<IEnumerable<Views.Models.Task>> GetTasksByListId(int listId);

        Task<Views.Models.Task> CreateTask(TaskToAddDTO task);

        Task<TaskToUpdateDTO> UpdateTask(TaskToUpdateDTO task);

        Task<TaskDTO> DeleteTask(int id);

        Task<bool> ChangeState(int id, bool state);
    }
}
