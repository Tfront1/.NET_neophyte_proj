using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.TeacherModel;

namespace neophyte_proj.WebApi.Models.IntermediateModels
{
    public class CourseTeacher
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TeacherId { get; set;}
        public Teacher Teacher { get; set; }
    }
}
