using ToDoList.API.Domain.DTOs;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Services.Interfaces;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        ITaskTagRepository _taskTagRepository;
        public TagService(ITagRepository tagRepository,ITaskTagRepository taskTagRepository)
        {
            _tagRepository = tagRepository;
            _taskTagRepository = taskTagRepository;
        }

        public async Task<Tag> CreateTagAsync(TagToAddDTO tag)
        {
            try
            {
                var create = new Tag
                {
                    TagName = tag.TagName,
                    UserId = tag.UserId
                };


                var created = await _tagRepository.CreateTagAsync(create);

                if(created.TagName is null) throw new Exception("Tag was not created");
                return created;
            }
            catch(Exception)
            {

                return new Tag();
            }
        }

        public async Task<Tag> DeleteTagAsync(int tag)
        {
            try
            {
                var find = await _tagRepository.GetTagByIdAsync(tag);
                if(find.TagName is null) throw new Exception("Tagul was not deleted");
                return find;
            }
            catch(Exception)
            {

                return new Tag();
            }
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            try
            {
                var find = await _tagRepository.GetTagByIdAsync(id);
                if(find is null) throw new Exception("Tag does not exist");
                return find;
            }
            catch(Exception)
            {
                return new Tag();
            }
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            try
            {
                var finds = await _tagRepository.GetTagsAsync();
                if(!finds.Any()) throw new Exception("There is not tag to show");
                return finds;
            }
            catch(Exception)
            {
                return Enumerable.Empty<Tag>();
            }
        }

        public async Task<IEnumerable<Tag>> GetTagsByTaskIdAsync(int id)
        {
            try
            {
                var find = await _taskTagRepository.GetTaskTagsByTaskIdAsync(id);
                if(find is null) throw new Exception("Task does not have any tags");

                var list = new List<Tag>();
                foreach(var item in find)
                {
                    var tag = await _tagRepository.GetTagByIdAsync(item.TagId);
                    list.Add(tag);
                }
                return list;

            }
            catch(Exception)
            {

                return new List<Tag>();
            }
        }

        public async Task<IEnumerable<Tag>> GetTagsByUserIdAsync(int id)
        {
            try
            {
                var find = await _tagRepository.GetTagsByUserIdAsync(id);
                if(find is null) throw new Exception("User does not have any task");
                return find;
            }
            catch(Exception)
            {

                return new List<Tag>();
            }
        }

        public async Task<Tag> UpdateTagAsync(TagToUpdateDTO tag)
        {
            try
            {
                var y = await _tagRepository.GetTagByIdAsync(tag.TagId);
                y.TagName = tag.TagName;

                var update = await _tagRepository.UpdateTagAsync(y);
                if(update.TagName is null) throw new Exception("Tag was not updated");
                return update;
            }
            catch(Exception)
            {
                return new Tag();
            }
        }
    }
}
