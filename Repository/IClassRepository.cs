using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repository
{
    public interface IClassRepository
    {
        void AddClass(MentorClass mentorClass);
        List<MentorClass> GetAllClasses();
        MentorClass? GetClassById(int classId);

        void UpdateClass(MentorClass mentorClass);
        void DeleteClass(int classId);
    }
}
