using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class EnrollmentDAO
    {
        private readonly MentorClassManagementContext _context;

        public EnrollmentDAO(MentorClassManagementContext context)
        {
            _context = context;
        }

        public void DeleteStudentEnrollment(int classId, int studentId)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(e => e.ClassId == classId && e.StudentId == studentId);
            if (enrollment != null) {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
            }
        }

        public void EnrollStudentToClass(int classId, int studentId)
        {
            var existing = _context.Enrollments.FirstOrDefault(e => e.ClassId == classId && e.StudentId == studentId);
            if(existing != null)
            {
                return;
            }

            var enrollment = new Enrollment
            {
                ClassId = classId,
                StudentId = studentId,
                EnrollmentDate = DateTime.Now,
                Note = ""
            };
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public List<EnrollmentStudent> GetStudentEnrollMentByClassId(int classId)
        {
            var studentEnrollments = (from e in _context.Enrollments
                                      join s in _context.Students on e.StudentId equals s.StudentId
                                      where e.ClassId == classId
                                      select new EnrollmentStudent
                                      {
                                          StudentId = s.StudentId,
                                          FullName = s.FullName,
                                          Email = s.Email,
                                          DateOfBirth = s.DateOfBirth.HasValue ? s.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue) : null,
                                          PhoneNumber = s.Phone,
                                          EnrollmentDate = e.EnrollmentDate,
                                          Note = e.Note,
                                      }).ToList();
            return studentEnrollments;
        }
    }
}
