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
            await _courseService.Create(courseDto).ConfigureAwait(false);
            return new JsonResult(Ok(courseDto));
        }
    }
}
