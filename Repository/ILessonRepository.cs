using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repository
{
    public interface ILessonRepository
    {
        List<Lesson> GetLessonsByClassId(int classId);
        Lesson GetLessonById(int lessonId);
        void AddLesson(Lesson lesson);

        void UpdateLesson(Lesson lesson);

        void DeleteLesson(int lessonId, int classId);
    }
}
