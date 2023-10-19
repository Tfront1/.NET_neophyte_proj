using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.WebApi.Models.StudentModel
{
    public class StudentDto
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

        public void Copy(Student student)
        {
            this.Id = student.Id;
        }
    }
}
