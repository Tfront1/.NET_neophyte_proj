﻿namespace neophyte_proj.DataAccess.Models.TeacherModel
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
    }
}