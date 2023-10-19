using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;

namespace neophyte_proj.WebApi.Services
{
    public interface ICourseService
    {
        Task<bool> Create(CourseDto dto);
        Task<CourseDto> GetById(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<CourseDto>> GetAll();
        Task<bool> Update(CourseDto dto);
        Task<IEnumerable<TeacherDto>> GetTeachers(int id);
        Task<IEnumerable<StudentDto>> GetStudents(int id);
    }
}
