using neophyte_proj.DataAccess.Models.StudentModel;
using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.DataAccess.Models.CourseModel
{
    public class CourseFeedBack
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }

        [MaxLength(20)]
        public string Tittle { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }

        //nto1
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //copy
        public async Task Copy(CourseFeedBack courseFeedBack)
        {
            if (courseFeedBack != null)
            {
                this.Rating = courseFeedBack.Rating;
                this.Tittle = courseFeedBack.Tittle;
                this.Text = courseFeedBack.Text;
            }    
        }
    }
}
