using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Services;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseBageController : ControllerBase
    {
        private readonly ICourseBageService _courseBageService;
        public CourseBageController(ICourseBageService courseBageService)
        {
            _courseBageService = courseBageService;
        }
        /// <summary>
        /// Method for creating new Course bage. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(CourseBageDto courseBageDto)
        {
            _ = courseBageDto ?? throw new ArgumentNullException(nameof(courseBageDto));
            if (await _courseBageService.Create(courseBageDto).ConfigureAwait(false))
            {
                return new JsonResult(Created(nameof(CourseBageDto), courseBageDto))
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
        /// Method for getting course abge by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var courseBageDto = await _courseBageService.GetById(id).ConfigureAwait(false);
            if (courseBageDto != null)
            {
                return new JsonResult(Ok(courseBageDto))
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
        /// Method for deleting course bage by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _courseBageService.Delete(id).ConfigureAwait(false))
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
        /// Method for updating course bage. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update(CourseBageDto courseBageDto)
        {
            _ = courseBageDto ?? throw new ArgumentNullException(nameof(courseBageDto));
            if (await _courseBageService.Update(courseBageDto).ConfigureAwait(false))
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
        /// Method for getting all courses bage. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseBageService.GetAll();
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
