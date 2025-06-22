using System;
using System.Collections.Generic;

namespace BusinessObjects;
public partial class Lesson
{
    public int LessonId { get; set; }

    public int ClassId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public int OrderNumber { get; set; }

    public bool? IsTaught { get; set; }

    public virtual Class Class { get; set; } = null!;
}
