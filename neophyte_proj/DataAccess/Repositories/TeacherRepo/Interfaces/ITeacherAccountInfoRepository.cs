using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.TeacherRepo.Interfaces
{
    public interface ITeacherAccountInfoRepository
    {
        IEnumerable<TeacherAccountInfo> GetAll();
        TeacherAccountInfo GetById(int id);
        TeacherAccountInfo GetByTeacherId(int id);
        void Create(TeacherAccountInfo teacherAccountInfo);
        void Update(TeacherAccountInfo teacherAccountInfo);
        void Delete(int id);
        void Save();
    }
}
