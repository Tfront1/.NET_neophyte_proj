using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using DataAccess.Repositories.StudentRepo.Interfaces;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.StudentModel;

namespace WebApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public StudentService(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }
        public async Task<bool> Create(StudentDto studentDto)
        {
            _ = studentDto ?? throw new ArgumentNullException(nameof(studentDto));

            var student = _mapper.Map<Student>(studentDto);
            var genInf = _mapper.Map<StudentGeneralInfo>(studentDto);
            student.Id = default;
            student.StudentGeneralInfo = genInf;

            if (!await _studentRepository.Create(student).ConfigureAwait(false))
            {
                return false;
            }
            return await _studentRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _studentRepository.Delete(id).ConfigureAwait(false))
            {
                return false;
            }
            return await _studentRepository.Save();
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            var students = await _studentRepository.GetAll();
            List<StudentDto> dto = new List<StudentDto>();
            foreach (Student s in students)
            {
                dto.Add(_mapper.Map<StudentDto>(s.StudentGeneralInfo));
                dto.Last().Copy(s);
            }
            return dto;
        }

        public async Task<StudentDto> GetById(int id)
        {
            var student = await _studentRepository.GetById(id).ConfigureAwait(false);
            if (student == null)
            {
                return null;
            }
            var studentDto = _mapper.Map<StudentDto>(student.StudentGeneralInfo);
            studentDto.Copy(student);
            return studentDto;
        }

        public async Task<IEnumerable<CourseDto>> GetCourses(int id)
        {
            var courses = await _studentRepository.GetCourses(id);
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

        public async Task<bool> Update(StudentDto studentDto)
        {
            _ = studentDto ?? throw new ArgumentNullException(nameof(studentDto));

            var student = _mapper.Map<Student>(studentDto);
            var genInf = _mapper.Map<StudentGeneralInfo>(studentDto);
            student.StudentGeneralInfo = genInf;

            if (!await _studentRepository.Update(student).ConfigureAwait(false))
            {
                return false;
            }
            return await _studentRepository.Save();
        }
    }
}
