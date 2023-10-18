using DataAccess.Repositories.CourseRepo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace neophyte_proj.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherDTO dto)
        {
            var creationResult = await _courseRepository.Create(dto).ConfigureAwait(false);

            return CreatedAtAction(
                nameof(GetById),
                new { id = creationResult.Teacher.Id, },
                new TeacherCreationResponse
                {
                    Teacher = creationResult.Teacher,
                    UploadingAvatarImageResult = creationResult.UploadingAvatarImageResult?.CreateSingleUploadingResult(),
                });
        }
    }
}
