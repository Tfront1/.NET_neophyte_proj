using neophyte_proj.WebApi.Models.CourseModel;

namespace neophyte_proj.WebApi.Services
{
    public interface ICourseService
    {
        Task Create(CourseDto dto);
    }
}
