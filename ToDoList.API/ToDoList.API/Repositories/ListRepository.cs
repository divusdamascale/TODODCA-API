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
            try
            {

                return await _context.Lists
                .Where(u => u.UserId == userId)
                .ToListAsync();
            }
            catch(Exception)
            {

                return new List<List>();
            }
        }

        public async Task<List> CreateList(List list)
        {
            try
            {
                await _context.Lists.AddAsync(list);
                await _context.SaveChangesAsync();
                return list;
            }
            catch(Exception)
            {

                return new List();
            }
        }

        public async Task<List> DeleteList(int id)
        {
            try
            {
                var lement = await _context.Lists.FindAsync(id);
                if(lement is null) throw new Exception("Nu exista lista");
                _context.Lists.Remove(lement);
                await _context.SaveChangesAsync();
                return lement;
            }
            catch(Exception)
            {

                return new List();
            }
        }
    }
}
