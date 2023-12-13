using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly TodolistdcaContext _context;

        public ListRepository(TodolistdcaContext context)
        {
            _context = context;
        }
        public async Task<List<List>> getListsByUserId(int userId)
        {
            
            return await _context.Lists
            .Where(u => u.UserId == userId)
            .ToListAsync(); ;
        }

        public async Task<List> CreateList(List list)
        {
            await _context.Lists.AddAsync(list);
            await _context.SaveChangesAsync();
            return list;
        }

        public async Task<List> DeleteList(int id)
        {
            var lement =await  _context.Lists.FindAsync(id);
            _context.Lists.Remove(lement);
            await _context.SaveChangesAsync();
            return lement;
        }
    }
}
