namespace ToDoList.API.Domain.DTOs
{
    public class TagToAddDTO
    {
        public int UserId { get; set; }
        public string TagName { get; set; } = null!;
    }
}
