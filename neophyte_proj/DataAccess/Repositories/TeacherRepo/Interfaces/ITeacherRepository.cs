using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.TeacherRepo.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAll();
        Task<Teacher> GetById(int id);
        Task Create(Teacher teacher);
        Task Update(Teacher teacher);
        Task Delete(int id);
        Task<bool> Save();
        Task<IEnumerable<Course>> GetCourses(int id);
    }
}
