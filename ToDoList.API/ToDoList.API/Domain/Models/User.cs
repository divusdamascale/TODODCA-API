using System;
using System.Collections.Generic;

namespace ToDoList.API.Views.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Pass { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual Profile? Profile { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
