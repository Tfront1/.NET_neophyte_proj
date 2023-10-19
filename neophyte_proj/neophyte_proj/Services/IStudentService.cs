using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModel;
using neophyte_proj.WebApi.Models.StudentModel;

namespace WebApi.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
        Task<bool> Create(StudentDto studentDto);
        Task<bool> Update(StudentDto studentDto);
        Task<bool> Delete(int id);
        Task<IEnumerable<CourseDto>> GetCourses(int id);
        Task<bool> AddCourse(CourseStudentDto courseStudentDto);
    }
}
