using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repository;

namespace Services
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository repository) {
            _studentRepository = repository;
        }
        public void AddStudent(Student student)
        {
            //Thêm logic kiểm tra nghiệp vụ
            if (_studentRepository.IsEmailExist(student.Email))
                throw new Exception("Email này đã tồn tại");
            _studentRepository.AddStudent(student);
        }

        public void DeleteStudent(Student student) => _studentRepository.DeleteStudent(student);

        public List<Student> GetAllStudents() => _studentRepository.GetAllStudents();

        public Student? GetStudentById(int id) => _studentRepository.GetStudentById(id);

        public bool IsEmailExist(string email) => _studentRepository.IsEmailExist(email);

        public void UpdateStudent(Student student) => _studentRepository.UpdateStudent(student);
    }
}
