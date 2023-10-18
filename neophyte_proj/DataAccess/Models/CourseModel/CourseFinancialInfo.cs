namespace neophyte_proj.DataAccess.Models.CourseModel
{
    public class CourseFinancialInfo
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        //1to1
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
