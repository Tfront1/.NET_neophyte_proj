using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.WebApi.Models.CourseModel
{
    public class CourseFeedBackDto
    {
        public int Id { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }
        [MaxLength(20)]
        public string Tittle { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
    }
}
