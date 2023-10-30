using ToDoList.API.Data;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Views.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.API.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly TodolistdcaContext _context;

        public ProfileRepository(TodolistdcaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Profile profile)
        { 
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
