using ToDoList.API.Domain.DTOs;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task<Tag> GetTagByIdAsync(int id);
        Task<IEnumerable<Tag>> GetTagsByUserIdAsync(int id);
        Task<Tag> GetTagByNameAsync(string name);
        Task<Tag> CreateTagAsync(Tag tag);
        Task<Tag> UpdateTagAsync(Tag tag);
        Task<Tag> DeleteTagAsync(Tag tag);
    }
}
