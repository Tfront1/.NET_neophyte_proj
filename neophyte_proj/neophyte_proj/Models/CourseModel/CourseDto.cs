using neophyte_proj.DataAccess.Models.CourseModel;

namespace neophyte_proj.WebApi.Models.CourseModel
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LessonsCount { get; set; }
        public int PlacesNumber { get; set; }
        public int Rate { get; set; }

        public void Copy(Course course) {
            this.Id = course.Id;
        }
    }
}
