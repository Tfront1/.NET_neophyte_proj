using neophyte_proj.Models.CourseModel;
using neophyte_proj.Models.IntermediateModels;
using neophyte_proj.Models.StudentModel;

namespace neophyte_proj.Models.TeacherModel
{
    public class Teacher
    {
        public int Id { get; set; }

        //Own
        public TeacherGeneralInfo TeacherGeneralInfo { get; set; }

        //1to1
        public int TeacherAccountInfoId { get; set; }
        public TeacherAccountInfo TeacherAccountInfo { get; set; }

        //1ton
        public ICollection<TeacherFeedBack> TeacherFeedBacks { get; set; }

        //nton
        public ICollection<CourseTeacher> CourseTeacher { get; set; }
    }
}
