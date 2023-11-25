using System;
using System.Collections.Generic;

namespace ToDoList.API.Views.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public int UserId { get; set; }

    public string TagName { get; set; } = null!;

    //public virtual User User { get; set; } = null!;
}
