using ToDoList.API.Domain.DTOs;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task<Tag> GetTagByIdAsync(int id);
        Task<IEnumerable<Tag>> GetTagsByUserIdAsync(int id);
        Task<IEnumerable<Tag>> GetTagsByTaskIdAsync(int id);
        Task<Tag> CreateTagAsync(TagToAddDTO tag);
        Task<Tag> UpdateTagAsync(TagToUpdateDTO tag);
        Task<Tag> DeleteTagAsync(int tag);
    }
}
