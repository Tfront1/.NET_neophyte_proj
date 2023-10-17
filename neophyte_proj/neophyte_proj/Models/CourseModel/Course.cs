using neophyte_proj.Models.IntermediateModels;
using neophyte_proj.Models.StudentModel;
using neophyte_proj.Models.TeacherModel;

namespace neophyte_proj.Models.CourseModel
{
    public class Course
    {
        public Guid Id { get; set; }

        //Own
        public CourseGeneralInfo CourseGeneralInfo { get; set; }

        //1to1
        public int CourseFinancialInfoId { get; set; }
        public CourseFinancialInfo CourseFinancialInfo { get; set; }

        //1ton
        public ICollection<CourseFeedBack> CourseFeedBacks { get; set; }
        public ICollection<CourseBage> CourseBages { get; set; }

        //nton
        public ICollection<CourseStudent> Students { get; set; }
        public ICollection<CourseTeacher> Teachers { get; set; }
    }
}
