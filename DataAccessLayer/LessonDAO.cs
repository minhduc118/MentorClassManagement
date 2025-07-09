using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class LessonDAO
    {
        private readonly MentorClassManagementContext _context;

        public LessonDAO(MentorClassManagementContext context) {
            _context = context;
        }

        public List<Lesson> GetLessonsByClassId(int classId) {
            return _context.Lessons.Where(c => c.ClassId == classId).ToList();
        }

        public Lesson GetLessonById(int lessonId) {
            return _context.Lessons.FirstOrDefault(c => c.LessonId == lessonId);
        }

        public void AddLesson(Lesson lesson) {
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
        }

        public void UpdateLesson(Lesson lesson) {
            _context.Lessons.Update(lesson);
            _context.SaveChanges();
        }

        public void DeleteLesson(int lessonId, int classId) {
            var lesson = _context.Lessons.FirstOrDefault(l => l.LessonId == lessonId  && l.ClassId == classId);

            if (lesson != null) {
                _context.Lessons.Remove(lesson);
                _context.SaveChanges();
            }
        }
    }
}
