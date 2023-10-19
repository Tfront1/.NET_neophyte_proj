using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;

namespace neophyte_proj.WebApi.Models.StudentModel
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int StudentAccountInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AboutMe { get; set; }

        public void Copy(Student student)
        {
            this.Id = student.Id;
            this.StudentAccountInfoId = student.StudentAccountInfoId;
        }
    }
}
