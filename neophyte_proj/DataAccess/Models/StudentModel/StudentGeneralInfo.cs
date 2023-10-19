using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.DataAccess.Models.StudentModel
{
    public class StudentGeneralInfo
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

        //copy
        public async Task Copy(StudentGeneralInfo studentGeneralInfo)
        {
            if (studentGeneralInfo != null){
                this.FirstName = studentGeneralInfo.FirstName;
                this.LastName = studentGeneralInfo.LastName;
                this.MiddleName = studentGeneralInfo.MiddleName;
                this.AboutMe = studentGeneralInfo.AboutMe;
            }
        }
    }
}
