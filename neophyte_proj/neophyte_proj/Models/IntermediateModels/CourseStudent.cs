using neophyte_proj.Models.CourseModel;
using neophyte_proj.Models.StudentModel;
using neophyte_proj.Models.TeacherModel;

namespace neophyte_proj.Models.IntermediateModels
{
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
