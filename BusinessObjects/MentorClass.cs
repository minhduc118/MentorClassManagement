using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class MentorClass
{
   

    public MentorClass()
    {
    }
    public MentorClass(MentorClass other)
    {
        this.ClassId = other.ClassId; 
        this.ClassName = other.ClassName;
        this.Description = other.Description;
        this.StartDate = other.StartDate;
        this.EndDate = other.EndDate;
        this.TuitionFee = other.TuitionFee;
    }
   

    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal TuitionFee { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
