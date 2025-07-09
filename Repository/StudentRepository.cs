using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDAO _studentDao;

        public StudentRepository(MentorClassManagementContext context) {
            _studentDao = new StudentDAO(context);
        }

        public void AddStudent(Student student) => _studentDao.AddStudent(student);

        public void DeleteStudent(Student student) => _studentDao.DeleteStudent(student);

        public List<Student> GetAllStudents() => _studentDao.GetAllStudents();

        public Student? GetStudentById(int id) => _studentDao.GetStudentById(id);

        public bool IsEmailExist(string email) => _studentDao.IsEmailExist(email);

        public void UpdateStudent(Student student) => _studentDao.UpdateStudent(student);
    }
}
