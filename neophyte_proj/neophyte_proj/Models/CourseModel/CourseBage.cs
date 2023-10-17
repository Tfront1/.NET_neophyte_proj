namespace neophyte_proj.Models.CourseModel
{
    public class CourseBage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        //nto1
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int BageId { get; set; }
        public CourseBage CourseBage { get; set; }
    }
}
