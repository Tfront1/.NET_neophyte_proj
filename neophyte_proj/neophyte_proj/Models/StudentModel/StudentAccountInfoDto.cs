using System.ComponentModel.DataAnnotations;

namespace neophyte_proj.WebApi.Models.StudentModel
{
    public class StudentAccountInfoDto
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
        public int StudentId { get; set; }
    }
}
