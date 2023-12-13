using ToDoList.API.Domain.DTOs;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Services.Interfaces;
using ToDoList.API.Views.Models;

namespace ToDoList.API.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _repo;

        public ListService(IListRepository repo)
        {
            _repo = repo;
        }

        public async Task<List> CreateList(ListToAddDTO list)
        {
            var listToAdd  = new List
            {
                Description = list.Description,
                ListName = list.ListName,
                StartDate = list.StartDate,
                UserId = list.UserId
            };

            var result = await _repo.CreateList(listToAdd);

            return result;

            
        }

        public async Task<List> DeleteList(int id)
        {
            var result = await _repo.DeleteList(id);
            return result;
        }

        public async Task<List<ListDTO>> GetListsByUserID(int userId)
        {
            var result = await _repo.getListsByUserId(userId);

            var Lists = new List<ListDTO>();

            foreach(var item in result)
            {
                var element = new ListDTO
                {
                    Description = item.Description,
                    ListId = item.ListId,
                    ListName = item.ListName,
                    StartDate = item.StartDate
                };

                Lists.Add(element);
            }

            return Lists;


        }
    }
}
