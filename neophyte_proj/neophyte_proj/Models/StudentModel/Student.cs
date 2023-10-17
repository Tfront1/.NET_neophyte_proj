using neophyte_proj.Models.CourseModel;
using neophyte_proj.Models.IntermediateModels;
using neophyte_proj.Models.TeacherModel;

namespace neophyte_proj.Models.StudentModel
{
    public class Student
    {
        public Guid Id { get; set; }

        //Own
        public StudentGeneralInfo StudentGeneralInfo { get; set; }

        //1to1
        public int StudentAccountInfoId { get; set; }
        public StudentGeneralInfo StudentAccountInfo { get; set; }

        //1ton
        public ICollection<CourseBage> CourseBages { get; set; }

        //nton
        public ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
