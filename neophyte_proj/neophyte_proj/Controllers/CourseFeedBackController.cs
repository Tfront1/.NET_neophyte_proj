using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.CourseModel;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseFeedBackController : ControllerBase
    {
        private readonly ICourseFeedBackService _courseFeedBackService;
        public CourseFeedBackController(ICourseFeedBackService courseFeedBackService)
        {
            _courseFeedBackService = courseFeedBackService;
        }
        /// <summary>
        /// Method for creating new Course feedback. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(CourseFeedBackDto courseFeedBackDto)
        {
            _ = courseFeedBackDto ?? throw new ArgumentNullException(nameof(courseFeedBackDto));
            if (await _courseFeedBackService.Create(courseFeedBackDto).ConfigureAwait(false))
            {
                return new JsonResult(Created(nameof(CourseBageDto), courseFeedBackDto))
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
        /// Method for getting course feedback by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var courseFeedbackDto = await _courseFeedBackService.GetById(id).ConfigureAwait(false);
            if (courseFeedbackDto != null)
            {
                return new JsonResult(Ok(courseFeedbackDto))
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
        /// Method for deleting course feedback by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _courseFeedBackService.Delete(id).ConfigureAwait(false))
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
        /// Method for updating course feedback. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update(CourseFeedBackDto courseFeedBackDto)
        {
            _ = courseFeedBackDto ?? throw new ArgumentNullException(nameof(courseFeedBackDto));
            if (await _courseFeedBackService.Update(courseFeedBackDto).ConfigureAwait(false))
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
        /// Method for getting all courses feedback. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseFeedBackService.GetAll();
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
        /// Method for getting course feedback by course id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByCourseId")]
        public async Task<IActionResult> GetByCourseId(int id)
        {
            var courseFeedBackDto = await _courseFeedBackService.GetByCourseId(id).ConfigureAwait(false);
            if (courseFeedBackDto != null)
            {
                return new JsonResult(Ok(courseFeedBackDto))
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
