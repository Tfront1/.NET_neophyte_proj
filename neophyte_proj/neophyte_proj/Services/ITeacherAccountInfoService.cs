using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.TeacherModel;

namespace WebApi.Services
{
    public interface ITeacherAccountInfoService
    {
        Task<bool> Create(TeacherAccountInfoDto dto);
        Task<TeacherAccountInfoDto> GetById(int id);
        Task<TeacherAccountInfoDto> GetByTeacherId(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<TeacherAccountInfoDto>> GetAll();
        Task<bool> Update(TeacherAccountInfoDto dto);
    }
}
