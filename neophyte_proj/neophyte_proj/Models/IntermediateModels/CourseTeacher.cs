using neophyte_proj.Models.CourseModel;
using neophyte_proj.Models.TeacherModel;

namespace neophyte_proj.Models.IntermediateModels
{
    public class CourseTeacher
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TeacherId { get; set;}
        public Teacher Teacher { get; set; }
    }
}
