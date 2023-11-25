using ToDoList.API.Domain.DTOs;
using ToDoList.API.Repositories.Interfaces;
using ToDoList.API.Services.Interfaces;

namespace ToDoList.API.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _repo;

        public ListService(IListRepository repo)
        {
            _repo = repo;
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
