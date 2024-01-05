namespace ToDoList.API.Domain.DTOs
{
    public class TaskToAddDTO
    {
        public int ListId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public DateTime EndDate { get; set; }
    }
}
