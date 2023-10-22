using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using System.Data;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Teacher,Admin")]
    [ApiController]
    public class TeacherAccountInfoController : ControllerBase
    {
        private readonly ITeacherAccountInfoService _teacherAccountInfoService;
        public TeacherAccountInfoController(ITeacherAccountInfoService teacherAccountInfoService)
        {
            _teacherAccountInfoService = teacherAccountInfoService;
        }
        /// <summary>
        /// Method for creating new teacher account info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(TeacherAccountInfoDto teacherAccountInfoDto)
        {
            _ = teacherAccountInfoDto ?? throw new ArgumentNullException(nameof(teacherAccountInfoDto));
            if (await _teacherAccountInfoService.Create(teacherAccountInfoDto).ConfigureAwait(false))
            {
                return new JsonResult(Created(nameof(TeacherAccountInfoDto), teacherAccountInfoDto))
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
        /// Method for getting teacher account info by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var teacherAccountInfoDto = await _teacherAccountInfoService.GetById(id).ConfigureAwait(false);
            if (teacherAccountInfoDto != null)
            {
                return new JsonResult(Ok(teacherAccountInfoDto))
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
        /// Method for getting teacher account info by teacher id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByTeacherId")]
        public async Task<IActionResult> GetByTeacherId(int id)
        {
            var teacherAccountInfoDto = await _teacherAccountInfoService.GetByTeacherId(id).ConfigureAwait(false);
            if (teacherAccountInfoDto != null)
            {
                return new JsonResult(Ok(teacherAccountInfoDto))
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
        /// Method for deleting teacher account info by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _teacherAccountInfoService.Delete(id).ConfigureAwait(false))
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
        /// Method for updationg teacher account info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update(TeacherAccountInfoDto teacherAccountInfoDto)
        {
            _ = teacherAccountInfoDto ?? throw new ArgumentNullException(nameof(teacherAccountInfoDto));
            if (await _teacherAccountInfoService.Update(teacherAccountInfoDto).ConfigureAwait(false))
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
        /// Method for getting all teachers account info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _teacherAccountInfoService.GetAll();
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
