namespace neophyte_proj.Models.TeacherModel
{
    public class TeacherAccountInfo
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        //1to1
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
