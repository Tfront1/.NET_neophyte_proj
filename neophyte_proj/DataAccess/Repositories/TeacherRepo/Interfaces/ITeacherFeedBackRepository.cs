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
        Task<IEnumerable<TeacherFeedBack>> GetAll();
        Task<TeacherFeedBack> GetById(int id);
        Task<IEnumerable<TeacherFeedBack>> GetByTeacherId(int id);
        Task Create(TeacherFeedBack teacherFeedBack);
        Task Update(TeacherFeedBack teacherFeedBack);
        Task Delete(int id);
        Task<bool> Save();
    }
}
