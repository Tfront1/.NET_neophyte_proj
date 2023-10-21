using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.TeacherModel;

namespace WebApi.Services
{
    public interface ITeacherFeedBackService
    {
        Task<IEnumerable<TeacherFeedBackDto>> GetAll();
        Task<TeacherFeedBackDto> GetById(int id);
        Task<IEnumerable<TeacherFeedBackDto>> GetByTeacherId(int id);
        Task<bool> Create(TeacherFeedBackDto teacherFeedBackDto);
        Task<bool> Update(TeacherFeedBackDto teacherFeedBackDto);
        Task<bool> Delete(int id);
    }
}
