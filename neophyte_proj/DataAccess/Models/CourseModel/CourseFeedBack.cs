namespace neophyte_proj.DataAccess.Models.CourseModel
{
    public class CourseFeedBack
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }
        public bool IsAuthorStudent { get; set; }

        //nto1
        public int CourseId { get; set; }
        public Course Course { get; set; }

        //copy
        public void Copy(CourseFeedBack courseFeedBack)
        {
            this.Author= courseFeedBack.Author;
            this.Rating= courseFeedBack.Rating;
            this.Tittle= courseFeedBack.Tittle;
            this.Text = courseFeedBack.Text;
            this.IsAuthorStudent = courseFeedBack.IsAuthorStudent;
        }
    }
}
