﻿using Microsoft.EntityFrameworkCore;

namespace neophyte_proj.DataAccess.Models.StudentModel
{
    public class StudentGeneralInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AboutMe { get; set; }

        //copy
        public async Task Copy(StudentGeneralInfo studentGeneralInfo)
        {
            if (studentGeneralInfo != null){
                this.FirstName = studentGeneralInfo.FirstName;
                this.LastName = studentGeneralInfo.LastName;
                this.MiddleName = studentGeneralInfo.MiddleName;
                this.AboutMe = studentGeneralInfo.AboutMe;
            }
        }
    }
}
