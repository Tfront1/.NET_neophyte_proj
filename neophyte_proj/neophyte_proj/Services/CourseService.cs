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
using Serilog;

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
            Log.Information("Creating course started {courseDto}",courseDto);
            _ = courseDto ?? throw new ArgumentNullException(nameof(courseDto));

            var course = _mapper.Map<Course>(courseDto);
            var genInf = _mapper.Map<CourseGeneralInfo>(courseDto);
            course.Id = default;
            course.CourseGeneralInfo = genInf;

            Log.Information("Course model {course}", course);
            if (!await _courseRepository.Create(course).ConfigureAwait(false)) {
                Log.Error("Bad reauest data,creating stoped {course}", course);
                return false;
            }
            return await _courseRepository.Save();
        }
        public async Task<CourseDto> GetById(int id) {
            Log.Information("Getting course by id started {id}", id);
            var course = await _courseRepository.GetById(id).ConfigureAwait(false);
            if (course == null) {
                Log.Error("No such course with id {id}", id);
                return null;
            }
            var courseDto = _mapper.Map<CourseDto>(course.CourseGeneralInfo);
            courseDto.Copy(course);
            Log.Information("Course finded {courseDto}", courseDto);
            return courseDto;
        }
        public async Task<bool> Delete(int id) {
            Log.Information("Deleting course by id started {id}", id);
            if (!await _courseRepository.Delete(id).ConfigureAwait(false)) {
                Log.Error("No such course with id {id}", id);
                return false;
            }
            Log.Information("Course deleted");
            return await _courseRepository.Save();
        }
        public async Task<bool> Update(CourseDto dto) {
            Log.Information("Updating course started {dto}", dto);
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var course = _mapper.Map<Course>(dto);
            var genInf = _mapper.Map<CourseGeneralInfo>(dto);
            course.CourseGeneralInfo = genInf;

            if (!await _courseRepository.Update(course).ConfigureAwait(false))
            {
                Log.Error("No such course {dto}", dto);
                return false;
            }
            Log.Information("Course updated {dto}", dto);
            return await _courseRepository.Save();
        }
        public async Task<IEnumerable<CourseDto>> GetAll() {
            Log.Information("Getting all courses started");
            var courses = await _courseRepository.GetAll();
            List<CourseDto> dto = new List<CourseDto>();
            foreach (Course c in courses) {
                dto.Add(_mapper.Map<CourseDto>(c.CourseGeneralInfo));
                dto.Last().Copy(c);
            }
            Log.Information("All courses ->{@dto}",dto);
            return dto;
        }
        public async Task<IEnumerable<TeacherDto>> GetTeachers(int id) {
            Log.Information("Getting teachers by course id started {id}",id);
            var teachers = await _courseRepository.GetTeachers(id);
            if (teachers == null)
            {
                Log.Error("No such course, or no teachers on it {id}", id);
                return null;
            }
            List<TeacherDto> teacherDtos = new List<TeacherDto>();
            foreach (Teacher t in teachers) {
                teacherDtos.Add(_mapper.Map<TeacherDto>(t.TeacherGeneralInfo));
                teacherDtos.Last().Copy(t);
            }
            Log.Information("Teachers finded ->{@teacherDtos}", teacherDtos);
            return teacherDtos;
        }
        public async Task<IEnumerable<StudentDto>> GetStudents(int id)
        {
            Log.Information("Getting students by course id started {id}", id);
            var students = await _courseRepository.GetStudents(id);
            if (students == null)
            {
                Log.Error("No such course, or no students on it {id}", id);
                return null;
            }
            List<StudentDto> studentDtos = new List<StudentDto>();
            foreach (Student s in students)
            {
                studentDtos.Add(_mapper.Map<StudentDto>(s.StudentGeneralInfo));
                studentDtos.Last().Copy(s);
            }
            Log.Information("Students finded ->{@studentDtos}", studentDtos);
            return studentDtos;
        }

        public async Task<IEnumerable<CourseBageDto>> GetBages(int id) {
            Log.Information("Getting bages by course id started {id}", id);
            var bages = await _courseRepository.GetBages(id);
            if (bages == null)
            {
                Log.Error("No such course, or no bages on it {id}", id);
                return null;
            }
            List<CourseBageDto> courseBageDtos = new List<CourseBageDto>();
            foreach (CourseBage s in bages)
            {
                courseBageDtos.Add(_mapper.Map<CourseBageDto>(s));
            }
            Log.Information("Bages finded ->{@courseBageDtos}", courseBageDtos);
            return courseBageDtos;
        }
    }
}
