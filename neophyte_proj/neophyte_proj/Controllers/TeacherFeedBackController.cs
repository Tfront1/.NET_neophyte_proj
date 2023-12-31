﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using System.Data;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Student,Admin")]
    [ApiController]
    public class TeacherFeedBackController : ControllerBase
    {
        private readonly ITeacherFeedBackService _teacherFeedBackService;
        public TeacherFeedBackController(ITeacherFeedBackService teacherFeedBackService)
        {
            _teacherFeedBackService = teacherFeedBackService;
        }
        /// <summary>
        /// Method for creating new Teacher feedback. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public async Task<IActionResult> Create(TeacherFeedBackDto teacherFeedBackDto)
        {
            _ = teacherFeedBackDto ?? throw new ArgumentNullException(nameof(teacherFeedBackDto));
            if (await _teacherFeedBackService.Create(teacherFeedBackDto).ConfigureAwait(false))
            {
                return new JsonResult(Created(nameof(TeacherFeedBackDto), teacherFeedBackDto))
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
        /// Method for getting teacher feedback by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var teacherFeedbackDto = await _teacherFeedBackService.GetById(id).ConfigureAwait(false);
            if (teacherFeedbackDto != null)
            {
                return new JsonResult(Ok(teacherFeedbackDto))
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
        /// Method for deleting teacher feedback by id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _teacherFeedBackService.Delete(id).ConfigureAwait(false))
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
        /// Method for updating teacher feedback. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPut]
        public async Task<IActionResult> Update(TeacherFeedBackDto teacherFeedBackDto)
        {
            _ = teacherFeedBackDto ?? throw new ArgumentNullException(nameof(teacherFeedBackDto));
            if (await _teacherFeedBackService.Update(teacherFeedBackDto).ConfigureAwait(false))
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
        /// Method for getting all teachers feedback. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _teacherFeedBackService.GetAll();
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
        /// Method for getting teacher feedback by teacher id. 
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("GetByCourseId")]
        public async Task<IActionResult> GetByCourseId(int id)
        {
            var teacherFeedBackDto = await _teacherFeedBackService.GetByTeacherId(id).ConfigureAwait(false);
            if (teacherFeedBackDto != null)
            {
                return new JsonResult(Ok(teacherFeedBackDto))
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
