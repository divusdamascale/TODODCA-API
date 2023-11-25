namespace ToDoList.API.Domain.DTOs
{
    public class ListDTO
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
    }
}
