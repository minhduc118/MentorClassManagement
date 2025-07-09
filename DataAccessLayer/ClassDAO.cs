using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class ClassDAO
    {
        private readonly MentorClassManagementContext _context;

        public ClassDAO(MentorClassManagementContext context)
        {
            _context = context;
        }

        public void AddClass(MentorClass mentorClass)
        {
            _context.Classes.Add(mentorClass);
            _context.SaveChanges();
        }

        public List<MentorClass> GetAllClasses() {
            return _context.Classes.ToList();
        }

        public MentorClass? GetClassById(int classId) {
            return _context.Classes.FirstOrDefault(c => c.ClassId == classId);
        }

        public void UpdateClass(MentorClass mentorClass) 
        {
            var existingClasses = _context.Classes.FirstOrDefault(x => x.ClassId == mentorClass.ClassId);
            if (existingClasses != null)
            {
                existingClasses.ClassName = mentorClass.ClassName;
                existingClasses.Description = mentorClass.Description;
                existingClasses.StartDate = mentorClass.StartDate;
                existingClasses.EndDate = mentorClass.EndDate;
                existingClasses.TuitionFee = mentorClass.TuitionFee;
                _context.SaveChanges();
            }

        }

        public void DeleteClass(int classId) 
        {
            var mentorClass = _context.Classes.FirstOrDefault(c => c.ClassId == classId);
            if (mentorClass != null) {
                var enrollments = _context.Enrollments.Where(e => e.ClassId == classId).ToList();
                _context.Enrollments.RemoveRange(enrollments);
                _context.Classes.Remove(mentorClass);
                _context.SaveChanges();
            }
        }
    }
}
