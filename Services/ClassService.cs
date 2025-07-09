using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repository;

namespace Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository) {
            _classRepository = classRepository;
        }
        public void AddClass(MentorClass mentorClass)
        {
            _classRepository.AddClass(mentorClass);
        }

        public void DeleteClass(int classId)
        {
            _classRepository.DeleteClass(classId);
        }

        public List<MentorClass> GetAllClasses() => _classRepository.GetAllClasses();

        public MentorClass? GetClassById(int classId) => _classRepository.GetClassById(classId);

        public void UpdateClass(MentorClass mentorClass)
        {
            _classRepository.UpdateClass(mentorClass);
        }
    }
}
