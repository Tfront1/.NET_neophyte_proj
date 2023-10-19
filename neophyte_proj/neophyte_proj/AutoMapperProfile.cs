using AutoMapper;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Models.CourseModel;

namespace neophyte_proj.WebApi
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, CourseGeneralInfo>();
            CreateMap<CourseGeneralInfo, CourseDto>();
        }
    }
}
