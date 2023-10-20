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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Method for creating new Course. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(CourseDto courseDto)
        {
            _ = courseDto ?? throw new ArgumentNullException(nameof(courseDto));
            if (await _courseService.Create(courseDto).ConfigureAwait(false)) {
                return new JsonResult(Created(nameof(CourseDto), courseDto))
                {
                    StatusCode = 201
                };
            }
            return new JsonResult(BadRequest())
            {
                StatusCode = 400
            };

        }

        /// <summary>
        /// Method for getting course by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetById(int id) {
            var courseDto = await _courseService.GetById(id).ConfigureAwait(false);
            if (courseDto != null) {
                return new JsonResult(Ok(courseDto))
                {
                    StatusCode = 200
                };
            }
            return new JsonResult(NotFound())
            {
                StatusCode = 404
            };
        }

        /// <summary>
        /// Method for deleting course by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            if (await _courseService.Delete(id).ConfigureAwait(false)) {
                return new JsonResult(Ok())
                {
                    StatusCode = 200
                };
            }
            return new JsonResult(NotFound())
            {
                StatusCode = 404
            };
        }

        /// <summary>
        /// Method for updationg course. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update(CourseDto courseDto)
        {
            _ = courseDto ?? throw new ArgumentNullException(nameof(courseDto));
            if (await _courseService.Update(courseDto).ConfigureAwait(false))
            {
                return new JsonResult(Ok())
                {
                    StatusCode = 200
                };
            }
            return new JsonResult(NotFound())
            {
                StatusCode = 404
            };
        }

        /// <summary>
        /// Method for getting all courses. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAll() {
            var result = _courseService.GetAll();
            if (result != null) {
                return new JsonResult(Ok(result))
                {
                    StatusCode = 200
                };
            }
            return new JsonResult(NotFound())
            {
                StatusCode = 404
            };
        }

        /// <summary>
        /// Method for getting all teachers of course by course id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetTeachers")]
        public async Task<IActionResult> GetTeachers(int id)
        {
            var result = _courseService.GetTeachers(id);
            if (result != null)
            {
                return new JsonResult(Ok(result))
                {
                    StatusCode = 200
                };
            }
            return new JsonResult(NotFound())
            {
                StatusCode = 404
            };
        }

        /// <summary>
        /// Method for getting all students of course by course id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents(int id)
        {
            var result = _courseService.GetStudents(id);
            if (result != null)
            {
                return new JsonResult(Ok(result))
                {
                    StatusCode = 200
                };
            }
            return new JsonResult(NotFound())
            {
                StatusCode = 404
            };
        }
    }
}
