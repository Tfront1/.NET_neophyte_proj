using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.DataAccess.Models.TeacherModel
{
    public class TeacherGeneralInfo
    {
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
        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rate { get; set; }

        //copy
        public async Task Copy(TeacherGeneralInfo teacherGeneralInfo)
        {
            if (teacherGeneralInfo != null) {
                this.FirstName = teacherGeneralInfo.FirstName;
                this.LastName = teacherGeneralInfo.LastName;
                this.MiddleName = teacherGeneralInfo.MiddleName;
                this.AboutMe = teacherGeneralInfo.AboutMe;
                this.Rate = teacherGeneralInfo.Rate;
            }
        }
    }
}
