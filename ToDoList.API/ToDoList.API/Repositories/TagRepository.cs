using Humanizer;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly TodolistdcaContext _context;
        public TagRepository(TodolistdcaContext context)
        {
            _context = context;
        }
        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            try
            {
                var x =  await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();
                return x.Entity;
            }
            catch
            {
                return new Tag();
            }
        }

        public async Task<Tag> DeleteTagAsync(Tag tag)
        {
            try
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                return tag;
            }catch
            {
                return new Tag();
            }
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            try
            {
                var find = await _context.Tags.FindAsync(id);
                if(find is null) throw new Exception("Tag not found");
                return find;
            
            }catch
            {
                return new Tag();
            }
        }

        public async Task<Tag> GetTagByNameAsync(string name)
        {
            try
            {
                var find = await _context.Tags.Where(x => x.TagName.ApplyCase(LetterCasing.LowerCase) == name.ApplyCase(LetterCasing.LowerCase)).FirstOrDefaultAsync();
                if(find is null) throw new Exception("Tag not found");
                return find;
            }catch
            {
                return new Tag();
            }
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            try
            {
                return await _context.Tags.ToListAsync();
            }
            catch
            {
                return new List<Tag>();
            }
        }

        public async Task<IEnumerable<Tag>> GetTagsByUserIdAsync(int id)
        {
            try
            { 
                return await _context.Tags.Where(x => x.UserId == id).ToListAsync();
            } 
            catch
            {
                return new List<Tag>();
            }
        }

        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            try
            {
                var y = _context.Update(tag);
                await _context.SaveChangesAsync();
                return y.Entity;

            }catch
            {
                   return new Tag();
            }
        }
    }
}
