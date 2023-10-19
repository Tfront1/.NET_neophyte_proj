namespace neophyte_proj.DataAccess.Models.CourseModel
{
    public class CourseGeneralInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int LessonsCount { get; set; }
        public int PlacesNumber { get; set; }
        public int Rate { get; set; }

        //copy
        public async Task Copy(CourseGeneralInfo courseGeneralInfo)
        {
            if (courseGeneralInfo != null) {
                this.Name = courseGeneralInfo.Name;
                this.Description = courseGeneralInfo.Description;
                this.LessonsCount = courseGeneralInfo.LessonsCount;
                this.PlacesNumber = courseGeneralInfo.PlacesNumber;
                this.Rate = courseGeneralInfo.Rate;
            }
        }
    }
}
