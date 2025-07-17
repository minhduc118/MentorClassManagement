using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DebtAmount => TotalAmount - PaidAmount;
        public string Status { get; set; }
    }
}
