using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;

namespace neophyte_proj.DataAccess.Models.TeacherModel
{
    public class Teacher
    {
        public int Id { get; set; }

        //Own
        public TeacherGeneralInfo TeacherGeneralInfo { get; set; }

        //1to1
        public int TeacherAccountInfoId { get; set; }
        public TeacherAccountInfo TeacherAccountInfo { get; set; }

        //1ton
        public ICollection<TeacherFeedBack> TeacherFeedBacks { get; set; }

        //nton
        public ICollection<CourseTeacher> CourseTeacher { get; set; }

        //copy
        public void Copy(Teacher teacher) {
            this.TeacherGeneralInfo.Copy(teacher.TeacherGeneralInfo);
            this.TeacherAccountInfo.Copy(teacher.TeacherAccountInfo);
            this.TeacherFeedBacks.Clear();
            foreach (TeacherFeedBack tfb in teacher.TeacherFeedBacks)
            {
                this.TeacherFeedBacks.Add(tfb);
            }
            this.CourseTeacher.Clear();
            foreach (CourseTeacher ctch in teacher.CourseTeacher)
            {
                this.CourseTeacher.Add(ctch);
            }
        }
    }
}
