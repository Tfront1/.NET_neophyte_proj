using Microsoft.EntityFrameworkCore;

namespace neophyte_proj.DataAccess.Models.StudentModel
{
    public class StudentGeneralInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AboutMe { get; set; }

        //copy
        public void Copy(StudentGeneralInfo studentGeneralInfo)
        {
            this.FirstName = studentGeneralInfo.FirstName;
            this.LastName = studentGeneralInfo.LastName;
            this.MiddleName = studentGeneralInfo.MiddleName;
            this.AboutMe = studentGeneralInfo.AboutMe;
        }
    }
}
