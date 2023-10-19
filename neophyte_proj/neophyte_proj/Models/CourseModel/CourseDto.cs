using neophyte_proj.DataAccess.Models.CourseModel;
using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.WebApi.Models.CourseModel
{
    public class CourseDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [Range(0, 500, ErrorMessage = "Lessons count must be between 0 and 500.")]
        public int LessonsCount { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Places count must be between 0 and 10000.")]
        public int PlacesNumber { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rate { get; set; }

        public void Copy(Course course) {
            this.Id = course.Id;
        }
    }
}
