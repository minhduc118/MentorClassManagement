using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class InvoiceRepository
    {
        private readonly InvoiceDAO invoiceDAO;

        public InvoiceRepository(MentorClassManagementContext context)
        {
            invoiceDAO = new InvoiceDAO(context);
        }

        public List<Invoice> GetAllInvoices()
        {
            return invoiceDAO.GetAllInvoiceWithStudentClass();
        }

        public Invoice GetInvoiceByIdWithDetails(int invoiceId)
        {
            return invoiceDAO.GetInvoiceByIdWithDetails(invoiceId);
        }
        public void ConfirmPayment(Invoice invoice)
        {
            decimal totalPaid = invoice.Payments?.Sum(p => p.Amount) ?? 0;
            decimal unpaid = invoice.TotalAmount - totalPaid;

            if (unpaid <= 0)
                return;

            var payment = new Payment
            {
                InvoiceId = invoice.InvoiceId,
                PaymentDate = DateTime.Now,
                Amount = unpaid,
                PaymentMethod = "Chuyển khoản",
                Note = "Xác nhận đã thanh toán"
            };

            invoiceDAO.AddPayment(payment);

            if (totalPaid + unpaid >= invoice.TotalAmount)
            {
                invoiceDAO.UpdateInvoiceStatus(invoice, "Paid");
            }
        }
    }
}
