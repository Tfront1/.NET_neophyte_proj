using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Services;
using System.Data;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Teacher,Admin")]
    [ApiController]
    public class CourseFinancialInfoController : ControllerBase
    {
        private readonly ICourseFinancialInfoService _courseFinancialInfoService;
        public CourseFinancialInfoController(ICourseFinancialInfoService courseFinancialInfoService)
        {
            _courseFinancialInfoService = courseFinancialInfoService;
        }
        /// <summary>
        /// Method for creating new Course financial info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(CourseFinancialInfoDto courseFinancialInfoDto)
        {
            _ = courseFinancialInfoDto ?? throw new ArgumentNullException(nameof(courseFinancialInfoDto));
            if (await _courseFinancialInfoService.Create(courseFinancialInfoDto).ConfigureAwait(false))
            {
                return new JsonResult(Created(nameof(CourseFinancialInfoDto), courseFinancialInfoDto))
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
        /// Method for getting course financial info by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var courseFinancialInfoDto = await _courseFinancialInfoService.GetById(id).ConfigureAwait(false);
            if (courseFinancialInfoDto != null)
            {
                return new JsonResult(Ok(courseFinancialInfoDto))
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
        /// Method for getting course financial info by course id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        [HttpGet("GetByCourseId")]
        public async Task<IActionResult> GetByCourseId(int id)
        {
            var courseFinancialInfoDto = await _courseFinancialInfoService.GetByCourseId(id).ConfigureAwait(false);
            if (courseFinancialInfoDto != null)
            {
                return new JsonResult(Ok(courseFinancialInfoDto))
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
        /// Method for deleting course financial info by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _courseFinancialInfoService.Delete(id).ConfigureAwait(false))
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
        /// Method for updationg course financial info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update(CourseFinancialInfoDto courseFinancialInfoDto)
        {
            _ = courseFinancialInfoDto ?? throw new ArgumentNullException(nameof(courseFinancialInfoDto));
            if (await _courseFinancialInfoService.Update(courseFinancialInfoDto).ConfigureAwait(false))
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
        /// Method for getting all courses financial info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseFinancialInfoService.GetAll();
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
