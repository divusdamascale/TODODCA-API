using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Repositories
{
    public class TaskTagRepository : ITaskTagRepository
    {
        private readonly TodolistdcaContext _context;
        public TaskTagRepository(TodolistdcaContext context)
        {
            _context = context;
        }
        public async Task<TaskTag> CreateTaskTagAsync(TaskTag taskTag)
        {
            try
            {
                await _context.TaskTags.AddAsync(taskTag);
                await _context.SaveChangesAsync();
                return taskTag;
            }
            catch
            {
                return new TaskTag();
            }
        }

        public async Task<TaskTag> DeleteTaskTagAsync(TaskTag taskTag)
        {
            try
            {
                _context.TaskTags.Remove(taskTag);
                await _context.SaveChangesAsync();
                return taskTag;
            }
            catch
            {
                return new TaskTag();
            }
        }

        public async Task<TaskTag> GetTaskTagByIdAsync(int id)
        {
            try
            {
                var find = await _context.TaskTags.FindAsync(id);
                if(find is null) throw new Exception("TaskTag not found");
                return find;
            }
            catch
            {
                return new TaskTag();
            }
        }

        public async Task<IEnumerable<TaskTag>> GetTaskTagsAsync()
        {
            try
            {
                return await _context.TaskTags.ToListAsync();
            }
            catch
            {
                return new List<TaskTag>();
            }
        }

        public async Task<TaskTag> GetTaskTagsByTagIdAsync(int id)
        {
            try
            {
                var find = await _context.TaskTags.FindAsync(id);
                if(find is null) throw new Exception("TaskTag not found");
                return find;
            }
            catch(Exception)
            {

                return new TaskTag();
            }
        }

        public async Task<IEnumerable<TaskTag>> GetTaskTagsByTaskIdAsync(int id)
        {
            try
            {
                return await _context.TaskTags.Where(x => x.TaskId == id).ToListAsync();
            }
            catch(Exception)
            {

                return new List<TaskTag>();
            }
        }

        public async Task<TaskTag> UpdateTaskTagAsync(TaskTag taskTag)
        {
            try
            {
                _context.Update(taskTag);
                await _context.SaveChangesAsync();
                return taskTag;
            }
            catch(Exception)
            {

                return new TaskTag();
            }
        }
    }
}
