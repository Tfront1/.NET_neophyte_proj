using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;

namespace neophyte_proj.WebApi.Services
{
    public interface ICourseService
    {
        Task<bool> Create(CourseDto dto);
        Task<CourseDto> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<Course>> GetAll();
        Task<bool> Update(CourseDto dto);
        Task<IEnumerable<Teacher>> GetTeachers(int id);
        Task<IEnumerable<Student>> GetStudents(int id);
    }
}
