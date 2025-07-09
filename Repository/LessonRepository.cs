using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly LessonDAO _dao;

        public LessonRepository(MentorClassManagementContext context)
        {
            _dao = new LessonDAO(context);
        }

        public void AddLesson(Lesson lesson)
        {
            _dao.AddLesson(lesson);
        }

        public void DeleteLesson(int lessonId, int classId)
        {
            _dao.DeleteLesson(lessonId, classId);
        }

        public Lesson GetLessonById(int lessonId)
        {
            return _dao.GetLessonById(lessonId);
        }

        public List<Lesson> GetLessonsByClassId(int classId)
        {
            return _dao.GetLessonsByClassId(classId);
        }

        public void UpdateLesson(Lesson lesson)
        {
            _dao.UpdateLesson(lesson);
        }
    }
}
