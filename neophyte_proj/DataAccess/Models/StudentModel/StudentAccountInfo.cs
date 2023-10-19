using neophyte_proj.DataAccess.Models.CourseModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace neophyte_proj.DataAccess.Models.StudentModel
{
    public class StudentAccountInfo
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        //1to1
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //copy
        public async Task Copy(StudentAccountInfo studentAccountInfo)
        {
            if (studentAccountInfo != null) {
                this.UserName = studentAccountInfo.UserName;
                this.Password = studentAccountInfo.Password;
                this.RegistrationDate = studentAccountInfo.RegistrationDate;
            }    
        }
    }
}
