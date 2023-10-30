using ToDoList.API.Views.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<int> SaveChangesAsync();
        Task<bool> ExistsByEmail(string email);
        Task<bool> ExistsByUsername(string username);

        Task<User> GetUserByUsernameAsync(string username);
    }
}
