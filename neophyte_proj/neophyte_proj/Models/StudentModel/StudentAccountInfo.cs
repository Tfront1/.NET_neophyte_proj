using System.Data;

namespace neophyte_proj.Models.StudentModel
{
    public class StudentAccountInfo
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        //1to1
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
