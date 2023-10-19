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
            _ = teacherDto ?? throw new ArgumentNullException(nameof(teacherDto));

            var teacher = _mapper.Map<Teacher>(teacherDto);
            var genInf = _mapper.Map<TeacherGeneralInfo>(teacherDto);
            teacher.Id = default;
            teacher.TeacherGeneralInfo = genInf;

            if (!await _teacherRepository.Create(teacher).ConfigureAwait(false))
            {
                return false;
            }
            return await _teacherRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _teacherRepository.Delete(id).ConfigureAwait(false))
            {
                return false;
            }
            return await _teacherRepository.Save();
        }

        public async Task<IEnumerable<TeacherDto>> GetAll()
        {
            var teachers = await _teacherRepository.GetAll();
            List<TeacherDto> dto = new List<TeacherDto>();
            foreach (Teacher t in teachers)
            {
                dto.Add(_mapper.Map<TeacherDto>(t.TeacherGeneralInfo));
                dto.Last().Copy(t);
            }
            return dto;
        }

        public async Task<TeacherDto> GetById(int id)
        {
            var teacher = await _teacherRepository.GetById(id).ConfigureAwait(false);
            if (teacher == null)
            {
                return null;
            }
            var teacherDto = _mapper.Map<TeacherDto>(teacher.TeacherGeneralInfo);
            teacherDto.Copy(teacher);
            return teacherDto;
        }

        public async Task<IEnumerable<CourseDto>> GetCourses(int id)
        {
            var courses = await _teacherRepository.GetCourses(id);
            if (courses == null)
            {
                return null;
            }
            List<CourseDto> courseDtos = new List<CourseDto>();
            foreach (Course c in courses)
            {
                courseDtos.Add(_mapper.Map<CourseDto>(c.CourseGeneralInfo));
                courseDtos.Last().Copy(c);
            }
            return courseDtos;
        }
        public async Task<bool> AddCourse(CourseTeacherDto courseTeacherDto)
        {
            var courseTeacher = _mapper.Map<CourseTeacher>(courseTeacherDto);
            if (!await _teacherRepository.AddCourse(courseTeacher))
            {
                return false;
            }
            return await _teacherRepository.Save();
        }

        public async Task<bool> Update(TeacherDto teacherDto)
        {
            _ = teacherDto ?? throw new ArgumentNullException(nameof(teacherDto));

            var teacher = _mapper.Map<Teacher>(teacherDto);
            var genInf = _mapper.Map<TeacherGeneralInfo>(teacherDto);
            teacher.TeacherGeneralInfo = genInf;

            if (!await _teacherRepository.Update(teacher).ConfigureAwait(false))
            {
                return false;
            }
            return await _teacherRepository.Save();
        }
    }
}
