using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int EnrollmentId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public string? Note { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
