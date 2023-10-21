using Microsoft.EntityFrameworkCore;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Models.CourseModel;

namespace WebApi.Services
{
    public interface ICourseBageService
    {
        public Task<IEnumerable<CourseBageDto>> GetAll();
        public Task<CourseBageDto> GetById(int id);
        public Task<IEnumerable<CourseBageDto>> GetByCourseId(int id);
        public Task<bool> Create(CourseBageDto courseBageDto);
        public Task<bool> Update(CourseBageDto courseBageDto);
        public Task<bool> Delete(int id);
    }
}
