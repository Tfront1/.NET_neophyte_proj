namespace neophyte_proj.WebApi.Models.TeacherModel
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AboutMe { get; set; }
        public int Rate { get; set; }
        public int TeacherAccountInfoId { get; set; }
    }
}
