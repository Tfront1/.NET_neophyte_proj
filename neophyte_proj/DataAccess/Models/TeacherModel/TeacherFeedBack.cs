namespace neophyte_proj.DataAccess.Models.TeacherModel
{
    public class TeacherFeedBack
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }

        //1ton
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        //copy
        public async Task Copy(TeacherFeedBack teacherFeedBack)
        {
            this.Author = teacherFeedBack.Author;
            this.Rating = teacherFeedBack.Rating;
            this.Tittle= teacherFeedBack.Tittle;
            this.Text = teacherFeedBack.Text;
        }
    }
}
