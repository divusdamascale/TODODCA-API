using ToDoList.API.Views.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.API.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task AddAsync(Profile profile);
        Task<int> SaveChangesAsync();
    }
}
