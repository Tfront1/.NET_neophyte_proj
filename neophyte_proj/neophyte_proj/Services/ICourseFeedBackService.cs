using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Models.CourseModel;

namespace WebApi.Services
{
    public interface ICourseFeedBackService
    {
        Task<IEnumerable<CourseFeedBackDto>> GetAll();
        Task<CourseFeedBackDto> GetById(int id);
        Task<IEnumerable<CourseFeedBackDto>> GetByCourseId(int id);
        Task<bool> Create(CourseFeedBackDto courseFeedBackDto);
        Task<bool> Update(CourseFeedBackDto courseFeedBackDto);
        Task<bool> Delete(int id);
    }
}
