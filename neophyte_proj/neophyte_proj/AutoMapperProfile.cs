using AutoMapper;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;

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
            CreateMap<CourseFinancialInfo, CourseFinancialInfoDto>();
            CreateMap<CourseFinancialInfoDto, CourseFinancialInfo>();

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, StudentGeneralInfo>();
            CreateMap<StudentGeneralInfo, StudentDto>();


            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, TeacherGeneralInfo>();
            CreateMap<TeacherGeneralInfo, TeacherDto>();
            CreateMap<TeacherAccountInfoDto, TeacherAccountInfo>();
            CreateMap<TeacherAccountInfo, TeacherAccountInfoDto>();


            CreateMap<CourseStudent, CourseStudentDto>();
            CreateMap<CourseStudentDto, CourseStudent>();
            CreateMap<CourseTeacher, CourseTeacherDto>();
            CreateMap<CourseTeacherDto, CourseTeacher>();
        }
    }
}
