using ToDoList.API.Views.Models;

namespace ToDoList.API.Utils.Interfaces
{
    public interface IJWTUtils
    {
        string CreateToken(User user);
    }
}
