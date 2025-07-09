using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class EnrollmentStudent
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = "";
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public string? Note { get; set; }
    }
}
