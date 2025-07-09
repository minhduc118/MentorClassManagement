using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repository
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);

        List<Student> GetAllStudents();

        Student? GetStudentById(int id);
        void UpdateStudent(Student student);

        void DeleteStudent(Student student);
        bool IsEmailExist(string email);
    }
}
