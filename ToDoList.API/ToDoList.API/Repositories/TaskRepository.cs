using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using ToDoList.API.Data;
using ToDoList.API.Domain.DTOs;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodolistdcaContext _context;

        public TaskRepository(TodolistdcaContext context)
        {
            _context = context;
        }

        public async Task<Views.Models.Task> CreateTask(Views.Models.Task task)
        {
            var addedTask = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            if(addedTask.Entity != null)
            {
                return task;
            }
            else
            {
                return new Views.Models.Task();
            }
        }

        public async Task<Views.Models.Task> DeleteTask(Views.Models.Task task)
        {
            if(task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return task;
            }
            else
            {
                return new Views.Models.Task();
            }
        }

        public async Task<IEnumerable<Views.Models.Task>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Views.Models.Task> GetTaskById(int id)
        {
            return await _context.Tasks.Where(t => t.TaskId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Views.Models.Task>> GetTasksByListId(int listId)
        {
            return await _context.Tasks.Where(t => t.ListId == listId).ToListAsync();
        }

        public async Task<Views.Models.Task> UpdateTask(Views.Models.Task task)
        {

            if(task is not null)
            {
            var updatedTask = _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
                if(updatedTask.Entity != null)
                {
                    return task;
                }
                else
                {
                    return new Views.Models.Task();
                }

            }else
            {
                return new Views.Models.Task();
            }


        }

       
    }
}
