using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Services;
using WebApi.Services;

namespace neophyte_proj.WebApi.Controllers
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

        /// <summary>
        /// Method for creating new Student. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            _ = studentDto ?? throw new ArgumentNullException(nameof(studentDto));
            if (await _studentService.Create(studentDto).ConfigureAwait(false))
            {
                return new JsonResult(Ok(studentDto));
            }
            return new JsonResult(BadRequest());

        }

        /// <summary>
        /// Method for getting student by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Method for deleting student by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _studentService.Delete(id).ConfigureAwait(false))
            {
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }

        /// <summary>
        /// Method for updationg student. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Method for getting all students. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/GetAllStudents")]
        public async Task<IActionResult> GetAll()
        {
            var result = _studentService.GetAll();
            if (result != null)
            {
                return new JsonResult(Ok(result));
            }
            return new JsonResult(NotFound());
        }

        /// <summary>
        /// Method for getting all courses of student by student id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/GetStudentCourses")]
        public async Task<IActionResult> GetCourses(int id)
        {
            var result = _studentService.GetCourses(id);
            if (result != null)
            {
                return new JsonResult(Ok(result));
            }
            return new JsonResult(NotFound());
        }

        /// <summary>
        /// Method for adding new cours to student by student id and course id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("/AddStudentCourse")]
        public async Task<IActionResult> AddCourse(CourseStudentDto courseStudentDto)
        {
            if (await _studentService.AddCourse(courseStudentDto))
            {
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }
    }
}
