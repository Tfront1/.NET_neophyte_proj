using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Services;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            _ = studentDto ?? throw new ArgumentNullException(nameof(studentDto));
            if (await _studentService.Create(studentDto).ConfigureAwait(false))
            {
                return new JsonResult(Ok(studentDto));
            }
            return new JsonResult("Invalid data");

        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var studentDto = await _studentService.GetById(id).ConfigureAwait(false);
            if (studentDto != null)
            {
                return new JsonResult(Ok(studentDto));
            }
            return new JsonResult(NotFound());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _studentService.Delete(id).ConfigureAwait(false))
            {
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudentDto studentDto)
        {
            _ = studentDto ?? throw new ArgumentNullException(nameof(studentDto));
            if (await _studentService.Update(studentDto).ConfigureAwait(false))
            {
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }

        [HttpGet("/GetAllStudents")]
        public async Task<IActionResult> GetAll()
        {
            var result = _studentService.GetAll();
            if (result != null)
            {
                return new JsonResult(result);
            }
            return new JsonResult(NotFound());
        }

        [HttpGet("/GetStudentCourses")]
        public async Task<IActionResult> GetCourses(int id)
        {
            var result = _studentService.GetCourses(id);
            if (result != null)
            {
                return new JsonResult(result);
            }
            return new JsonResult(NotFound());
        }
    }
}
