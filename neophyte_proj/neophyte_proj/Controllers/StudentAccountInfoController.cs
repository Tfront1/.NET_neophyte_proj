using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAccountInfoController : ControllerBase
    {
        private readonly IStudentAccountInfoService _studentAccountInfoService;
        public StudentAccountInfoController(IStudentAccountInfoService studentAccountInfoService)
        {
            _studentAccountInfoService = studentAccountInfoService;
        }
        /// <summary>
        /// Method for creating new student account info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(StudentAccountInfoDto studentAccountInfoDto)
        {
            _ = studentAccountInfoDto ?? throw new ArgumentNullException(nameof(studentAccountInfoDto));
            if (await _studentAccountInfoService.Create(studentAccountInfoDto).ConfigureAwait(false))
            {
                return new JsonResult(Created(nameof(TeacherAccountInfoDto), studentAccountInfoDto))
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
        /// Method for getting student account info by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var studentAccountInfoDto = await _studentAccountInfoService.GetById(id).ConfigureAwait(false);
            if (studentAccountInfoDto != null)
            {
                return new JsonResult(Ok(studentAccountInfoDto))
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
        /// Method for getting student account info by teacher id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByStudentId")]
        public async Task<IActionResult> GetByStudentId(int id)
        {
            var studentAccountInfoDto = await _studentAccountInfoService.GetByStudentId(id).ConfigureAwait(false);
            if (studentAccountInfoDto != null)
            {
                return new JsonResult(Ok(studentAccountInfoDto))
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
        /// Method for deleting student account info by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _studentAccountInfoService.Delete(id).ConfigureAwait(false))
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
        /// Method for updationg sudent account info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update(StudentAccountInfoDto studentAccountInfoDto)
        {
            _ = studentAccountInfoDto ?? throw new ArgumentNullException(nameof(studentAccountInfoDto));
            if (await _studentAccountInfoService.Update(studentAccountInfoDto).ConfigureAwait(false))
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
        /// Method for getting all students account info. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _studentAccountInfoService.GetAll();
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
