namespace neophyte_proj.WebApi.Models.TeacherModel
{
    public class TeacherAccountInfoDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int TeacherId { get; set; }
    }
}
