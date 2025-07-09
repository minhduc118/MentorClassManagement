using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class EnrolmentRepository
    {
        private readonly EnrollmentDAO _enrollmentDAO;

        public EnrolmentRepository(MentorClassManagementContext context) {
            _enrollmentDAO = new EnrollmentDAO(context);
        }

        public List<EnrollmentStudent> GetStudentsByClassId(int classId)
        {
            return _enrollmentDAO.GetStudentEnrollMentByClassId(classId);
        }

        public void EnrollStudentToClass(int classId, int studentId) {
            _enrollmentDAO.EnrollStudentToClass(classId, studentId);
        }

        public void DeleteStudentEnrollment(int classId, int studentId)
        {
            _enrollmentDAO.DeleteStudentEnrollment(classId, studentId);
        }
    }
}
