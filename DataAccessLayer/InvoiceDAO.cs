using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class InvoiceDAO
    {
        private readonly MentorClassManagementContext _context;

        public InvoiceDAO(MentorClassManagementContext context)
        {
            _context = context;
        }

        public List<Invoice> GetAllInvoiceWithStudentClass()
        {
            var enrollmentsWithoutInvoices = _context.Enrollments.Where(e => !_context.Invoices.Any(i => i.EnrollmentId == e.EnrollmentId)).ToList();
            foreach (var enrollment in enrollmentsWithoutInvoices)
            {
                var tuitionFee = enrollment.Class?.TuitionFee ?? _context.Classes.FirstOrDefault(c => c.ClassId == enrollment.ClassId)?.TuitionFee ?? 0;
                var invoice = new Invoice
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    InvoiceDate = DateTime.Now,
                    TotalAmount = tuitionFee,
                    Status = "Unpaid",
                    Note = null
                };
                _context.Invoices.Add(invoice);
            }

            _context.SaveChanges();

            var invoices = _context.Invoices
       .Include(i => i.Enrollment)
           .ThenInclude(e => e.Student)
       .Include(i => i.Enrollment)
           .ThenInclude(e => e.Class)
       .Include(i => i.Payments)
       .ToList();

            return invoices;
        }

        public Invoice GetInvoiceByIdWithDetails(int invoiceId)
        {
            return _context.Invoices
                .Where(i => i.InvoiceId == invoiceId)
                .Select(i => new Invoice
                {
                    InvoiceId = i.InvoiceId,
                    InvoiceDate = i.InvoiceDate,
                    TotalAmount = i.TotalAmount,
                    Status = i.Status,
                    Note = i.Note,
                    Enrollment = new Enrollment
                    {
                        EnrollmentId = i.Enrollment.EnrollmentId,
                        EnrollmentDate = i.Enrollment.EnrollmentDate,
                        Student = new Student
                        {
                            StudentId = i.Enrollment.Student.StudentId,
                            FullName = i.Enrollment.Student.FullName,
                            Email = i.Enrollment.Student.Email
                        },
                        Class = new MentorClass
                        {
                            ClassId = i.Enrollment.Class.ClassId,
                            ClassName = i.Enrollment.Class.ClassName,
                            TuitionFee = i.Enrollment.Class.TuitionFee
                        }
                    },
                    Payments = i.Payments.ToList()
                })
                .FirstOrDefault();
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void UpdateInvoiceStatus(Invoice invoice, string newStatus)
        {
            invoice.Status = newStatus;
            _context.Invoices.Update(invoice);
            _context.SaveChanges();
        }
    }
}
