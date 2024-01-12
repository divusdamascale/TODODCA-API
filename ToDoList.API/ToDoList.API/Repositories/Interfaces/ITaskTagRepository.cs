using ToDoList.API.Views.Models;

namespace ToDoList.API.Repositories.Interfaces
{
    public interface ITaskTagRepository
    {
        Task<IEnumerable<TaskTag>> GetTaskTagsAsync();
        Task<TaskTag> GetTaskTagByIdAsync(int id);
        Task<IEnumerable<TaskTag>> GetTaskTagsByTaskIdAsync(int id);
        Task<TaskTag> GetTaskTagsByTagIdAsync(int id);
        Task<TaskTag> CreateTaskTagAsync(TaskTag taskTag);
        Task<TaskTag> UpdateTaskTagAsync(TaskTag taskTag);
        Task<TaskTag> DeleteTaskTagAsync(TaskTag taskTag);
    }
}
