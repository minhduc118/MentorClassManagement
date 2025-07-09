using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ClassDAO _classDAO;

        public ClassRepository(MentorClassManagementContext context) {
            _classDAO = new ClassDAO(context);
        }
        public void AddClass(MentorClass mentorClass) => _classDAO.AddClass(mentorClass);

        public void DeleteClass(int classId) => _classDAO.DeleteClass(classId);

        public List<MentorClass> GetAllClasses() => _classDAO.GetAllClasses();

        public MentorClass? GetClassById(int classId) => _classDAO.GetClassById(classId);

        public void UpdateClass(MentorClass mentorClass) => _classDAO.UpdateClass(mentorClass);
    }
}
