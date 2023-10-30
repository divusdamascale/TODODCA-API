using System;
using System.Collections.Generic;

namespace ToDoList.API.Views.Models;

public partial class TaskTag
{
    public int TaskId { get; set; }

    public int TagId { get; set; }

    public virtual Tag Tag { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
