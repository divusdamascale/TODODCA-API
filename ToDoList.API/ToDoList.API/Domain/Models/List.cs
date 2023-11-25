using System;
using System.Collections.Generic;

namespace ToDoList.API.Views.Models;

public partial class List
{
    public int ListId { get; set; }

    public int UserId { get; set; }

    public string ListName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    //public virtual User User { get; set; } = null!;
}
