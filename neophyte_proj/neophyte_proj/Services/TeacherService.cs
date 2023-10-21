using AutoMapper;
using DataAccess.Repositories.StudentRepo.Interfaces;
using DataAccess.Repositories.StudentRepo.Repos;
using DataAccess.Repositories.TeacherRepo.Interfaces;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using Serilog;

namespace WebApi.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(IMapper mapper, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }
        public async Task<bool> Create(TeacherDto teacherDto)
        {
            Log.Information("Creating teacher started {teacherDto}", teacherDto);
            _ = teacherDto ?? throw new ArgumentNullException(nameof(teacherDto));

            var teacher = _mapper.Map<Teacher>(teacherDto);
            var genInf = _mapper.Map<TeacherGeneralInfo>(teacherDto);
            teacher.Id = default;
            teacher.TeacherGeneralInfo = genInf;

            Log.Information("Teacher model {teacher}", teacher);
            if (!await _teacherRepository.Create(teacher).ConfigureAwait(false))
            {
                Log.Error("Bad reauest data,creating stoped {teacher}", teacher);
                return false;
            }
            return await _teacherRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Log.Information("Deleting teacher by id started {id}", id);
            if (!await _teacherRepository.Delete(id).ConfigureAwait(false))
            {
                Log.Error("No such teacher with id {id}", id);
                return false;
            }
            Log.Information("Teacher deleted");
            return await _teacherRepository.Save();
        }

        public async Task<IEnumerable<TeacherDto>> GetAll()
        {
            Log.Information("Getting all teachers started");
            var teachers = await _teacherRepository.GetAll();
            List<TeacherDto> dto = new List<TeacherDto>();
            foreach (Teacher t in teachers)
            {
                dto.Add(_mapper.Map<TeacherDto>(t.TeacherGeneralInfo));
                dto.Last().Copy(t);
            }
            Log.Information("All teachers ->{@dto}", dto);
            return dto;
        }

        public async Task<TeacherDto> GetById(int id)
        {
            Log.Information("Getting teacher by id started {id}", id);
            var teacher = await _teacherRepository.GetById(id).ConfigureAwait(false);
            if (teacher == null)
            {
                Log.Error("No such teacher with id {id}", id);
                return null;
            }
            var teacherDto = _mapper.Map<TeacherDto>(teacher.TeacherGeneralInfo);
            teacherDto.Copy(teacher);
            Log.Information("Teacher finded {teacherDto}", teacherDto);
            return teacherDto;
        }

        public async Task<IEnumerable<CourseDto>> GetCourses(int id)
        {
            Log.Information("Getting courses by teacher id started {id}", id);
            var courses = await _teacherRepository.GetCourses(id);
            if (courses == null)
            {
                Log.Error("No such teacher, or no courses on it {id}", id);
                return null;
            }
            List<CourseDto> courseDtos = new List<CourseDto>();
            foreach (Course c in courses)
            {
                courseDtos.Add(_mapper.Map<CourseDto>(c.CourseGeneralInfo));
                courseDtos.Last().Copy(c);
            }
            Log.Information("Courses finded ->{@courseDtos}", courseDtos);
            return courseDtos;
        }
        public async Task<bool> AddCourse(CourseTeacherDto courseTeacherDto)
        {
            Log.Information("Adding course to teacher started {courseTeacherDto}", courseTeacherDto);
            var courseTeacher = _mapper.Map<CourseTeacher>(courseTeacherDto);
            if (!await _teacherRepository.AddCourse(courseTeacher))
            {
                Log.Error("Course didn't add");
                return false;
            }
            Log.Information("Course add");
            return await _teacherRepository.Save();
        }

        public async Task<bool> Update(TeacherDto teacherDto)
        {
            Log.Information("Updating teacher started {teacherDto}", teacherDto);
            _ = teacherDto ?? throw new ArgumentNullException(nameof(teacherDto));

            var teacher = _mapper.Map<Teacher>(teacherDto);
            var genInf = _mapper.Map<TeacherGeneralInfo>(teacherDto);
            teacher.TeacherGeneralInfo = genInf;

            if (!await _teacherRepository.Update(teacher).ConfigureAwait(false))
            {
                Log.Error("No such teacher {teacherDto}", teacherDto);
                return false;
            }
            Log.Information("Course updated {teacherDto}", teacherDto);
            return await _teacherRepository.Save();
        }
        public async Task<IEnumerable<TeacherFeedBackDto>> GetFeedbacks(int id)
        {
            Log.Information("Getting feedbacks by teacher id started {id}", id);
            var feedbacks = await _teacherRepository.GetFeedbacks(id);
            if (feedbacks == null)
            {
                Log.Error("No such teacher, or no feedbacks on it {id}", id);
                return null;
            }
            List<TeacherFeedBackDto> teacherFeedBackDtos = new List<TeacherFeedBackDto>();
            foreach (TeacherFeedBack s in feedbacks)
            {
                teacherFeedBackDtos.Add(_mapper.Map<TeacherFeedBackDto>(s));
            }
            Log.Information("Feedbacks finded ->{@teacherFeedBackDtos}", teacherFeedBackDtos);
            return teacherFeedBackDtos;
        }
    }
}
