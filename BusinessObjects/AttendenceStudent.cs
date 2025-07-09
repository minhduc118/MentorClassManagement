using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class AttendenceStudent
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public bool IsPresent { get; set; }
        public string Note { get; set; }
    }
}
