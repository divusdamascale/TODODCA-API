namespace ToDoList.API.Domain.DTOs
{
    public class ListToAddDTO
    {
        public string ListName { get; set; }

        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
    }
}
