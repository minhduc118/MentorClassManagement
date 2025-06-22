using System;
using System.Collections.Generic;

namespace BusinessObjects;
public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int ClassId { get; set; }

    public int StudentId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Student Student { get; set; } = null!;
}
