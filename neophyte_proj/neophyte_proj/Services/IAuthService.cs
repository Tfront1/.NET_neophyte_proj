using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using WebApi.Models;
using WebApi.Models.Auth;

namespace WebApi.Services
{
    public interface IAuthService
    {
        public Task<string> StudentLogin(UserStudentDto userStudentDto);

        public Task<string> TeacherLogin(UserTeacherDto userTeacherDto);

        public Task<string> AdminLogin(AdminDto adminDto);
    }
}
