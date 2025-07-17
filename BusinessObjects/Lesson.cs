using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int ClassId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public string? Record { get; set; }

    public bool? IsTaught { get; set; }

    public DateTime? TeachingDate { get; set; }
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual MentorClass Class { get; set; } = null!;
}
