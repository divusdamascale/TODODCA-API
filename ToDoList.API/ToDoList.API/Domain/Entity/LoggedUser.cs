using ToDoList.API.Views.Models;

namespace ToDoList.API.Domain.Entity
{
    public class LoggedUser
    {
        public int UserId { get; set; }

        public string Token { get; set; }
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public virtual ICollection<List> Lists { get; set; } = new List<List>();

        public virtual Profile? Profile { get; set; }

        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
