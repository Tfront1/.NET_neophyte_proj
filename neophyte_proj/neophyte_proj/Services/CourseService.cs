using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using DataAccess.Repositories.TeacherRepo.Repos;
using Microsoft.Extensions.Logging;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.StudentModel;
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

            if (!await _courseRepository.Create(course).ConfigureAwait(false)) {
                return false;
            }
            return await _courseRepository.Save();
        }
        public async Task<CourseDto> GetById(int id) {
            var course = await _courseRepository.GetById(id).ConfigureAwait(false);
            if (course == null) {
                return null;
            }
            var courseDto = _mapper.Map<CourseDto>(course.CourseGeneralInfo);
            courseDto.Copy(course);
            return courseDto;
        }
        public async Task<bool> Delete(int id) {
            if (!await _courseRepository.Delete(id).ConfigureAwait(false)) {
                return false;
            }
            return await _courseRepository.Save();
        }
        public async Task<bool> Update(CourseDto dto) {
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var course = _mapper.Map<Course>(dto);
            var genInf = _mapper.Map<CourseGeneralInfo>(dto);
            course.CourseGeneralInfo = genInf;

            if (!await _courseRepository.Update(course).ConfigureAwait(false))
            {
                return false;
            }
            return await _courseRepository.Save();
        }
        public async Task<IEnumerable<CourseDto>> GetAll() {
            var courses = await _courseRepository.GetAll();
            List<CourseDto> dto = new List<CourseDto>();
            foreach (Course c in courses) {
                dto.Add(_mapper.Map<CourseDto>(c.CourseGeneralInfo));
                dto.Last().Copy(c);
            }
            return dto;
        }
        public async Task<IEnumerable<TeacherDto>> GetTeachers(int id) {
            var teachers = await _courseRepository.GetTeachers(id);
            if (teachers == null)
            {
                return null;
            }
            List<TeacherDto> teacherDtos = new List<TeacherDto>();
            foreach (Teacher t in teachers) {
                teacherDtos.Add(_mapper.Map<TeacherDto>(t.TeacherGeneralInfo));
                teacherDtos.Last().Copy(t);
            }
            return teacherDtos;
        }
        public async Task<IEnumerable<StudentDto>> GetStudents(int id)
        {
            var students = await _courseRepository.GetStudents(id);
            if (students == null)
            {
                return null;
            }
            List<StudentDto> studentDtos = new List<StudentDto>();
            foreach (Student s in students)
            {
                studentDtos.Add(_mapper.Map<StudentDto>(s.StudentGeneralInfo));
                studentDtos.Last().Copy(s);
            }
            return studentDtos;
        }
    }
}
