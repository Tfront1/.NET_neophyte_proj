using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;

namespace WebApi.Services
{
    public interface IStudentAccountInfoService
    {
        Task<bool> Create(StudentAccountInfoDto dto);
        Task<StudentAccountInfoDto> GetById(int id);
        Task<StudentAccountInfoDto> GetByStudentId(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<StudentAccountInfoDto>> GetAll();
        Task<bool> Update(StudentAccountInfoDto dto);
    }
}
