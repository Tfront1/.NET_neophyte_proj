using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Models.CourseModel;

namespace WebApi.Services
{
    public interface ICourseFinancialInfoService
    {
        Task<bool> Create(CourseFinancialInfoDto dto);
        Task<CourseFinancialInfoDto> GetById(int id);
        Task<CourseFinancialInfoDto> GetByCourseId(int id);
        Task<bool> Delete(int id);
        Task<IEnumerable<CourseFinancialInfoDto>> GetAll();
        Task<bool> Update(CourseFinancialInfoDto dto);
    }
}
