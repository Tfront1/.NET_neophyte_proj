using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.TeacherRepo.Interfaces
{
    public interface ITeacherFeedBackRepository
    {
        IEnumerable<TeacherFeedBack> GetAll();
        TeacherFeedBack GetById(int id);
        IEnumerable<TeacherFeedBack> GetByTeacherId(int id);
        void Create(TeacherFeedBack teacherFeedBack);
        void Update(TeacherFeedBack teacherFeedBack);
        void Delete(int id);
        void Save();
    }
}
