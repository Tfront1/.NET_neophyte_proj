using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;

namespace neophyte_proj.DataAccess.Models.CourseModel
{
    public class Course
    {
        public int Id { get; set; }

        //Own
        public CourseGeneralInfo CourseGeneralInfo { get; set; }

        //1to1
        public int CourseFinancialInfoId { get; set; }
        public CourseFinancialInfo CourseFinancialInfo { get; set; }

        //1ton
        public ICollection<CourseFeedBack> CourseFeedBacks { get; set; }
        public ICollection<CourseBage> CourseBages { get; set; }

        //nton
        public ICollection<CourseStudent> CourseStudent { get; set; }
        public ICollection<CourseTeacher> CourseTeacher { get; set; }

        //Meth
        public async Task Copy(Course course)
        {
            await this.CourseGeneralInfo.Copy(course.CourseGeneralInfo);
            if (course.CourseFinancialInfo != null) {
                await this.CourseFinancialInfo.Copy(course.CourseFinancialInfo);
            }  
        }

    }
}
