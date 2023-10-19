using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;

namespace WebApi.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAll();
        Task<TeacherDto> GetById(int id);
        Task<bool> Create(TeacherDto teacherDto);
        Task<bool> Update(TeacherDto teacherDto);
        Task<bool> Delete(int id);
        Task<IEnumerable<CourseDto>> GetCourses(int id);
    }
}
