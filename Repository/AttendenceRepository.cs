using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class AttendenceRepository
    {
        private AttendenceDAO _attendenceDAO;

        public AttendenceRepository(MentorClassManagementContext context)
        {
            _attendenceDAO = new AttendenceDAO(context);
        }

        public List<AttendenceStudent> GetAttendenceStudents(int lessonId, int classId)
        {
            return _attendenceDAO.GetAttendanceByLesson(lessonId, classId);
        }

        public void UpdateAttendenceStudent(int lessonId, List<AttendenceStudent> attendenceStudents)
        {
            _attendenceDAO.UpdateAttendance(lessonId, attendenceStudents);
        }

    }
}
