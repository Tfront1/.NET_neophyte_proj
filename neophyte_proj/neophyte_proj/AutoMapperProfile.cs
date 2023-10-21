using AutoMapper;
using DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using WebApi.Models.IntermediateModel;

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
            CreateMap<CourseBageDto, CourseBage>();
            CreateMap<CourseBage, CourseBageDto>();
            CreateMap<CourseFeedBackDto, CourseFeedBack>();
            CreateMap<CourseFeedBack, CourseFeedBackDto>();

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, StudentGeneralInfo>();
            CreateMap<StudentGeneralInfo, StudentDto>();
            CreateMap<StudentAccountInfoDto, StudentAccountInfo>();
            CreateMap<StudentAccountInfo, StudentAccountInfoDto>();


            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, TeacherGeneralInfo>();
            CreateMap<TeacherGeneralInfo, TeacherDto>();
            CreateMap<TeacherAccountInfoDto, TeacherAccountInfo>();
            CreateMap<TeacherAccountInfo, TeacherAccountInfoDto>();
            CreateMap<TeacherFeedBackDto, TeacherFeedBack>();
            CreateMap<TeacherFeedBack, TeacherFeedBackDto>();


            CreateMap<CourseStudent, CourseStudentDto>();
            CreateMap<CourseStudentDto, CourseStudent>();
            CreateMap<CourseTeacher, CourseTeacherDto>();
            CreateMap<CourseTeacherDto, CourseTeacher>();
            CreateMap<BageStudent, BageStudentDto>();
            CreateMap<BageStudentDto, BageStudent>();
        }
    }
}
