using System;
using System.Collections.Generic;

namespace ToDoList.API.Views.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public int ListId { get; set; }

    public string TaskName { get; set; } = null!;

    public DateTime EndDate { get; set; }

    public bool State { get; set; }

    public virtual List List { get; set; } = null!;
}
