using Microsoft.EntityFrameworkCore;

namespace neophyte_proj.WebApi.Models.StudentModel
{
    public class StudentGeneralInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AboutMe { get; set; }
    }
}
