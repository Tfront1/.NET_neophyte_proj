using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using DataAccess.Repositories.TeacherRepo.Repos;
using Microsoft.Extensions.Logging;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
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
        public async Task<bool> Create(CourseDto courseDto)
        {
            _ = courseDto ?? throw new ArgumentNullException(nameof(courseDto));

            var course = _mapper.Map<Course>(courseDto);
            var genInf = _mapper.Map<CourseGeneralInfo>(courseDto);
            course.Id = default;
            course.CourseGeneralInfo = genInf;

            await _courseRepository.Create(course).ConfigureAwait(false);
            if (await _courseRepository.Save()) {
                return true;
            }
            return false;
        }
        public async Task<CourseDto> GetById(int id) {
            var course = await _courseRepository.GetById(id).ConfigureAwait(false);
            var courseDto = _mapper.Map<CourseDto>(course.CourseGeneralInfo);
            courseDto.Copy(course);
            if (course != null) {
                return courseDto;
            }
            return null;
        }
        public async Task<bool> Delete(int id) {
            await _courseRepository.Delete(id).ConfigureAwait(false);
            return await _courseRepository.Save();
        }
        public async Task<bool> Update(CourseDto dto) {
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var course = _mapper.Map<Course>(dto);
            var genInf = _mapper.Map<CourseGeneralInfo>(dto);
            course.CourseGeneralInfo = genInf;

            await _courseRepository.Update(course).ConfigureAwait(false);
            if (await _courseRepository.Save())
            {
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Course>> GetAll() {
            return await _courseRepository.GetAll();
        }
        public async Task<IEnumerable<Teacher>> GetTeachers(int id) {
            return await _courseRepository.GetTeachers(id);
        }
        public async Task<IEnumerable<Student>> GetStudents(int id)
        {
            return await _courseRepository.GetStudents(id);
        }
    }
}
