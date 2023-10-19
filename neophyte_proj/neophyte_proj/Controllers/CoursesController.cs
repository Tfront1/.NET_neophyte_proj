using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Services;

namespace neophyte_proj.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseDto courseDto)
        {
            _ = courseDto ?? throw new ArgumentNullException(nameof(courseDto));
            if (await _courseService.Create(courseDto).ConfigureAwait(false)) {
                return new JsonResult(Ok(courseDto));
            }
            return new JsonResult("Invalid data");

        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id) {
            var courseDto = await _courseService.GetById(id).ConfigureAwait(false);
            if (courseDto != null) {
                return new JsonResult(Ok(courseDto));
            }
            return new JsonResult(NotFound());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            if (await _courseService.Delete(id).ConfigureAwait(false)) {
                return new JsonResult(Ok());
            }
            return new JsonResult("Can't delete");
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseDto courseDto)
        {
            _ = courseDto ?? throw new ArgumentNullException(nameof(courseDto));
            if (await _courseService.Update(courseDto).ConfigureAwait(false))
            {
                return new JsonResult(Ok());
            }
            return new JsonResult("Can't update");
        }

        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAll() {
            var result = _courseService.GetAll();
            if (result != null) {
                return new JsonResult(result);
            }
            return new JsonResult(NotFound());
        }

        [HttpGet("/GetTeachers")]
        public async Task<IActionResult> GetTeachers(int id)
        {
            var result = _courseService.GetTeachers(id);
            if (result != null)
            {
                return new JsonResult(result);
            }
            return new JsonResult(NotFound());
        }

        [HttpGet("/GetStudents")]
        public async Task<IActionResult> GetStudents(int id)
        {
            var result = _courseService.GetStudents(id);
            if (result != null)
            {
                return new JsonResult(result);
            }
            return new JsonResult(NotFound());
        }
    }
}
