using neophyte_proj.Models.CourseModel;
using neophyte_proj.Models.StudentModel;

namespace neophyte_proj.Models.TeacherModel
{
    public class Teacher
    {
        public Guid Id { get; set; }

        //Own
        public StudentGeneralInfo TeacherGeneralInfo { get; set; }

        //1to1
        public int TeacherAccountInfoId { get; set; }
        public StudentGeneralInfo TeacherAccountInfo { get; set; }

        //1ton
        public ICollection<TeacherFeedBack> TeacherFeedBacks { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
