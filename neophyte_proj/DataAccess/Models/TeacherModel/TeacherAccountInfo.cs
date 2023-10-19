using neophyte_proj.DataAccess.Models.StudentModel;
using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.DataAccess.Models.TeacherModel
{
    public class TeacherAccountInfo
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
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //copy
        public async Task Copy(TeacherAccountInfo teacherAccountInfo)
        {
            if (teacherAccountInfo != null) {
                this.UserName = teacherAccountInfo.UserName;
                this.Password = teacherAccountInfo.Password;
                this.RegistrationDate = teacherAccountInfo.RegistrationDate;
            }
        }
    }
}
