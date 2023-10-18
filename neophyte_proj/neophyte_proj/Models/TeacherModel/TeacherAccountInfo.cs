namespace neophyte_proj.WebApi.Models.TeacherModel
{
    public class TeacherAccountInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        //1to1
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
