using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.TeacherModel;

namespace neophyte_proj.DataAccess.Models.StudentModel
{
    public class Student
    {
        public int Id { get; set; }

        //Own
        public StudentGeneralInfo StudentGeneralInfo { get; set; }

        //1to1
        public int StudentAccountInfoId { get; set; }
        public StudentAccountInfo StudentAccountInfo { get; set; }

        //1ton
        public ICollection<CourseBage> CourseBages { get; set; }

        //nton
        public ICollection<CourseStudent> CourseStudent { get; set; }

        //copy
        public void Copy(Student student)
        {
            this.StudentGeneralInfo.Copy(student.StudentGeneralInfo);
            this.StudentAccountInfo.Copy(student.StudentAccountInfo);
        }
    }
}
