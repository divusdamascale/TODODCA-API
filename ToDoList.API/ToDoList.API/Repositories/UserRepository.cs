using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Views.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodolistdcaContext _context;

        public UserRepository(TodolistdcaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
           await _context.Users.AddAsync(user);
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsByUsername(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u =>u.Profile)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
