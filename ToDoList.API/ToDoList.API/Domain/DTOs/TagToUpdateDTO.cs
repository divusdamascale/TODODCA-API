namespace ToDoList.API.Domain.DTOs
{
    public class TagToUpdateDTO
    {
        public int TagId { get; set; }
        public string TagName { get; set; } = null!;
    }
}
