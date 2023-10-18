namespace neophyte_proj.WebApi.Models.StudentModel
{
    public class StudentAccountInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int StudentId { get; set; }
    }
}
