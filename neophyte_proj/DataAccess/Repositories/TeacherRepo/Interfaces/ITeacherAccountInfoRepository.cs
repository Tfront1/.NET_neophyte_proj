using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
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
        Task<IEnumerable<TeacherAccountInfo>> GetAll();
        Task<IEnumerable<TeacherAccountInfo>> GetByUsername(string username);
        Task<TeacherAccountInfo> GetById(int id);
        Task<TeacherAccountInfo> GetByTeacherId(int id);
        Task<bool> Create(TeacherAccountInfo teacherAccountInfo);
        Task<bool> Update(TeacherAccountInfo teacherAccountInfo);
        Task<bool> Delete(int id);
        Task<bool> Save();
    }
}
