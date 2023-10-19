namespace neophyte_proj.DataAccess.Models.TeacherModel
{
    public class TeacherGeneralInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AboutMe { get; set; }
        public int Rate { get; set; }

        //copy
        public async Task Copy(TeacherGeneralInfo teacherGeneralInfo)
        {
            if (teacherGeneralInfo != null) {
                this.FirstName = teacherGeneralInfo.FirstName;
                this.LastName = teacherGeneralInfo.LastName;
                this.MiddleName = teacherGeneralInfo.MiddleName;
                this.AboutMe = teacherGeneralInfo.AboutMe;
                this.Rate = teacherGeneralInfo.Rate;
            }
        }
    }
}
