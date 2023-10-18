using neophyte_proj.DataAccess.Models.StudentModel;

namespace neophyte_proj.DataAccess.Models.CourseModel
{
    public class CourseBage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        //nto1
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
