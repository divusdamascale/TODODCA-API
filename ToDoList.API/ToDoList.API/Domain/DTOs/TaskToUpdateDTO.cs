namespace ToDoList.API.Domain.DTOs
{
    public class TaskToUpdateDTO
    {
        public int TaskId { get; set; }
        public int ListId { get; set; }
        public string TaskName { get; set; } = null!;
        public DateTime EndDate { get; set; }
        public bool State { get; set; }
    }
}
