using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using DataAccess.Repositories.TeacherRepo.Repos;
using Microsoft.Extensions.Logging;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.TeacherModel;

namespace neophyte_proj.WebApi.Services
{
    public class CourseService: ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }
        public async Task Create(CourseDto courseDto)
        {
            _ = courseDto ?? throw new ArgumentNullException(nameof(courseDto));

            var course = _mapper.Map<Course>(courseDto);
            var genInf = _mapper.Map<CourseGeneralInfo>(courseDto);
            course.Id = default;
            course.CourseGeneralInfo = genInf;

            await _courseRepository.Create(course).ConfigureAwait(false);
            await _courseRepository.Save();
        }
    }
}
