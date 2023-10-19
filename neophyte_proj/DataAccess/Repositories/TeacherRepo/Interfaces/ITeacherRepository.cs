using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
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
        Task<bool> Create(Teacher teacher);
        Task<bool> Update(Teacher teacher);
        Task<bool> Delete(int id);
        Task<bool> Save();
        Task<IEnumerable<Course>> GetCourses(int id);
        Task<bool> AddCourse(CourseTeacher courseTeacher);
    }
}
