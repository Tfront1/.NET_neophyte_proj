using AutoMapper;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.StudentModel;

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

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, StudentGeneralInfo>();
            CreateMap<StudentGeneralInfo, StudentDto>();
        }
    }
}
