using System.Data;

namespace neophyte_proj.DataAccess.Models.StudentModel
{
    public class StudentAccountInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        //1to1
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //copy
        public async Task Copy(StudentAccountInfo studentAccountInfo)
        {
            this.UserName= studentAccountInfo.UserName;
            this.Password= studentAccountInfo.Password;
            this.RegistrationDate= studentAccountInfo.RegistrationDate;
        }
    }
}
