using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModels;
using neophyte_proj.WebApi.Models.TeacherModel;

namespace neophyte_proj.WebApi.Models.StudentModel
{
    public class Student
    {
        public int Id { get; set; }

        //Own
        public StudentGeneralInfo StudentGeneralInfo { get; set; }

        //1to1
        public int StudentAccountInfoId { get; set; }
        public StudentAccountInfo StudentAccountInfo { get; set; }

        //1ton
        public ICollection<CourseBage> CourseBages { get; set; }

        //nton
        public ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
