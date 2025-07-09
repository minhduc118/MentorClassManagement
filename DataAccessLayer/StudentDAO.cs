using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class StudentDAO
    {
        private readonly MentorClassManagementContext _context;

        public StudentDAO(MentorClassManagementContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student? GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.FullName = student.FullName;
                existingStudent.Email = student.Email;
                existingStudent.Phone = student.Phone;
                existingStudent.DateOfBirth = student.DateOfBirth;
                _context.SaveChanges();
            }
        }

        public void DeleteStudent(Student student)
        {
            var studentRemove = _context.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (studentRemove != null) {
                _context.Students.Remove(studentRemove);
                _context.SaveChanges();
            }
        }
        public bool IsEmailExist(string email)
        {
            return _context.Students.Any(s => s.Email == email);
        }
    }
}
