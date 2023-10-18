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
        public void Copy(Course course)
        {
            this.CourseGeneralInfo.Copy(course.CourseGeneralInfo);
            this.CourseFinancialInfo.Copy(course.CourseFinancialInfo);
            this.CourseFeedBacks.Clear();
            foreach (CourseFeedBack cfb in course.CourseFeedBacks)
            {
                this.CourseFeedBacks.Add(cfb);
            }
            this.CourseBages.Clear();
            foreach (CourseBage cfb in course.CourseBages)
            {
                this.CourseBages.Add(cfb);
            }
            this.CourseStudent.Clear();
            foreach (CourseStudent cfb in course.CourseStudent)
            {
                this.CourseStudent.Add(cfb);
            }
            this.CourseTeacher.Clear();
            foreach (CourseTeacher cfb in course.CourseTeacher)
            {
                this.CourseTeacher.Add(cfb);
            }

        }

    }
}
