using System;
using System.Collections.Generic;

namespace ToDoList.API.Views.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual User User { get; set; } = null!;
}
