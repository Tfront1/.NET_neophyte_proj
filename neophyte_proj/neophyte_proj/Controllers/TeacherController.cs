using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherDto teacherDto)
        {
            _ = teacherDto ?? throw new ArgumentNullException(nameof(teacherDto));
            if (await _teacherService.Create(teacherDto).ConfigureAwait(false))
            {
                return new JsonResult(Ok(teacherDto));
            }
            return new JsonResult("Invalid data");

        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var teacherDto = await _teacherService.GetById(id).ConfigureAwait(false);
            if (teacherDto != null)
            {
                return new JsonResult(Ok(teacherDto));
            }
            return new JsonResult(NotFound());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _teacherService.Delete(id).ConfigureAwait(false))
            {
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }

        [HttpPut]
        public async Task<IActionResult> Update(TeacherDto teacherDto)
        {
            _ = teacherDto ?? throw new ArgumentNullException(nameof(teacherDto));
            if (await _teacherService.Update(teacherDto).ConfigureAwait(false))
            {
                return new JsonResult(Ok());
            }
            return new JsonResult(NotFound());
        }

        [HttpGet("/GetAllTeachers")]
        public async Task<IActionResult> GetAll()
        {
            var result = _teacherService.GetAll();
            if (result != null)
            {
                return new JsonResult(result);
            }
            return new JsonResult(NotFound());
        }

        [HttpGet("/GetTeacherCourses")]
        public async Task<IActionResult> GetCourses(int id)
        {
            var result = _teacherService.GetCourses(id);
            if (result != null)
            {
                return new JsonResult(result);
            }
            return new JsonResult(NotFound());
        }
    }
}
