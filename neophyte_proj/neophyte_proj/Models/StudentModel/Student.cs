namespace neophyte_proj.Models.StudentModel
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AboutMe { get; set; }
        public int Rate { get; set; }

    }
}
