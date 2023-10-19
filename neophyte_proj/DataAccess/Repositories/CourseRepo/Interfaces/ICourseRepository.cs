using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.CourseRepo.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
        Task Create(Course course);
        Task Update(Course course);
        Task Delete(int id);
        Task<bool> Save();
        Task<IEnumerable<Teacher>> GetTeachers(int id);
        Task<IEnumerable<Student>> GetStudents(int id);
    }
}
