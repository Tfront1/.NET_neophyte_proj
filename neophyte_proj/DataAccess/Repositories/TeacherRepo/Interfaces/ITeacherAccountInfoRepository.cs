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
        Task<IEnumerable<TeacherAccountInfo>> GetAll();
        Task<TeacherAccountInfo> GetById(int id);
        Task<TeacherAccountInfo> GetByTeacherId(int id);
        Task Create(TeacherAccountInfo teacherAccountInfo);
        Task Update(TeacherAccountInfo teacherAccountInfo);
        Task Delete(int id);
        Task<bool> Save();
    }
}
