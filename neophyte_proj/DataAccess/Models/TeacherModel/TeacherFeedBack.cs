using neophyte_proj.DataAccess.Models.StudentModel;
using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.DataAccess.Models.TeacherModel
{
    public class TeacherFeedBack
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }

        [MaxLength(20)]
        public string Tittle { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }

        //1ton
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //copy
        public async Task Copy(TeacherFeedBack teacherFeedBack)
        {
            if (teacherFeedBack != null) {
                this.Rating = teacherFeedBack.Rating;
                this.Tittle = teacherFeedBack.Tittle;
                this.Text = teacherFeedBack.Text;
            }
        }
    }
}
