using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.WebApi.Models.TeacherModel
{
    public class TeacherDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string MiddleName { get; set; }
        [MaxLength(1000)]
        public string AboutMe { get; set; }
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rate { get; set; }

        public void Copy(Teacher teacher)
        {
            this.Id = teacher.Id;
        }
    }
}
