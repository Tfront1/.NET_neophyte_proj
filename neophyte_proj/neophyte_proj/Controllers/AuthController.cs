using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using neophyte_proj.WebApi.Services;
using WebApi.Models.Auth;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("StudentLogin")]
        public async Task<IActionResult> StudentLogin(UserStudentDto userStudentDto)
        {
            var res = await _authService.StudentLogin(userStudentDto);
            if (res == null) {
                return new JsonResult(BadRequest("No such student"))
                {
                    StatusCode = 400
                };
            }
            return new JsonResult(Ok(res))
            {
                StatusCode = 200
            };
        }

        [HttpPost("TeacherLogin")]
        public async Task<IActionResult> TeacherLogin(UserTeacherDto userTeacherDto)
        {
            var res = await _authService.TeacherLogin(userTeacherDto);
            if (res == null)
            {
                return new JsonResult(BadRequest("No such teacher"))
                {
                    StatusCode = 400
                };
            }
            return new JsonResult(Ok(res))
            {
                StatusCode = 200
            };
        }
    }
}
