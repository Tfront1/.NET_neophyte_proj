using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Auth
{
    public class UserStudentDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
