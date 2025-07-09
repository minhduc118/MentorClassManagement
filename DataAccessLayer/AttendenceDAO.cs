using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class AttendenceDAO
    {
        private readonly MentorClassManagementContext _context;

        public AttendenceDAO(MentorClassManagementContext context)
        {
            _context = context;
        }

        public List<AttendenceStudent> GetAttendanceByLesson(int lessonId, int classId)
        {
            var studentList = (from e in _context.Enrollments
                               join s in _context.Students on e.StudentId equals s.StudentId
                               where e.ClassId == classId
                               select new AttendenceStudent
                               {
                                   StudentID = e.StudentId,
                                   FullName = s.FullName,
                                   IsPresent = false,
                                   Note = ""
                               }).ToList();

            var existingAttendence = _context.Attendances.Where(a => a.LessonId == lessonId).ToList();

            foreach (var student in studentList)
            {
                var attend = existingAttendence.FirstOrDefault(a => a.StudentId == student.StudentID);
                if (attend != null)
                {
                    student.IsPresent = attend.IsPresent;
                    student.Note = attend.Note;
                }
            }
            return studentList;
        }

        public void UpdateAttendance(int lessonId, List<AttendenceStudent> attendences)
        {
            foreach (var item in attendences)
            {
                var existing = _context.Attendances.FirstOrDefault(a => a.LessonId == lessonId && a.StudentId == item.StudentID);

                if (existing != null)
                {
                    existing.IsPresent = item.IsPresent;
                    existing.Note = item.Note;
                }
                else
                {
                    var newAttendance = new Attendance
                    {
                        LessonId = lessonId,
                        StudentId = item.StudentID,
                        IsPresent = item.IsPresent,
                        Note = item.Note
                    };
                    _context.Attendances.Add(newAttendance);
                }
            }
            _context.SaveChanges();
        }

    }
}
