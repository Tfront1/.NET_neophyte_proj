namespace neophyte_proj.WebApi.Models.CourseModel
{
    public class CourseDto
    {
        public int Id { get; set; }
        public int CourseFinancialInfoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LessonsCount { get; set; }
        public int PlacesNumber { get; set; }
        public int Rate { get; set; }
    }
}
