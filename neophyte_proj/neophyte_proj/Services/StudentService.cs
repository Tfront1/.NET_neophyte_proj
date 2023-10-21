using AutoMapper;
using DataAccess.Models.IntermediateModels;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using DataAccess.Repositories.StudentRepo.Interfaces;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.IntermediateModels;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using Serilog;
using WebApi.Models.IntermediateModel;

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
            Log.Information("Creating student started {studentDto}", studentDto);
            _ = studentDto ?? throw new ArgumentNullException(nameof(studentDto));

            var student = _mapper.Map<Student>(studentDto);
            var genInf = _mapper.Map<StudentGeneralInfo>(studentDto);
            student.Id = default;
            student.StudentGeneralInfo = genInf;

            Log.Information("Student model {student}", student);
            if (!await _studentRepository.Create(student).ConfigureAwait(false))
            {
                Log.Error("Bad reauest data,creating stoped {student}", student);
                return false;
            }
            return await _studentRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Log.Information("Deleting student by id started {id}", id);
            if (!await _studentRepository.Delete(id).ConfigureAwait(false))
            {
                Log.Error("No such student with id {id}", id);
                return false;
            }
            Log.Information("Student deleted");
            return await _studentRepository.Save();
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            Log.Information("Getting all students started");
            var students = await _studentRepository.GetAll();
            List<StudentDto> dto = new List<StudentDto>();
            foreach (Student s in students)
            {
                dto.Add(_mapper.Map<StudentDto>(s.StudentGeneralInfo));
                dto.Last().Copy(s);
            }
            Log.Information("All students ->{@dto}", dto);
            return dto;
        }

        public async Task<StudentDto> GetById(int id)
        {
            Log.Information("Getting student by id started {id}", id);
            var student = await _studentRepository.GetById(id).ConfigureAwait(false);
            if (student == null)
            {
                Log.Error("No such student with id {id}", id);
                return null;
            }
            var studentDto = _mapper.Map<StudentDto>(student.StudentGeneralInfo);
            studentDto.Copy(student);
            Log.Information("Student finded {studentDto}", studentDto);
            return studentDto;
        }

        public async Task<IEnumerable<CourseDto>> GetCourses(int id)
        {
            Log.Information("Getting courses by student id started {id}", id);
            var courses = await _studentRepository.GetCourses(id);
            if (courses == null)
            {
                Log.Error("No such student, or no courses on it {id}", id);
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
        public async Task<bool> AddCourse(CourseStudentDto courseStudentDto)
        {
            Log.Information("Adding course to student started {courseStudentDto}", courseStudentDto);
            var courseStudent = _mapper.Map<CourseStudent>(courseStudentDto);
            if (!await _studentRepository.AddCourse(courseStudent))
            {
                Log.Error("Course didn't add");
                return false;
            }
            Log.Information("Course add");
            return await _studentRepository.Save();
        }

        public async Task<bool> Update(StudentDto studentDto)
        {
            Log.Information("Updating student started {studentDto}", studentDto);
            _ = studentDto ?? throw new ArgumentNullException(nameof(studentDto));

            var student = _mapper.Map<Student>(studentDto);
            var genInf = _mapper.Map<StudentGeneralInfo>(studentDto);
            student.StudentGeneralInfo = genInf;

            if (!await _studentRepository.Update(student).ConfigureAwait(false))
            {
                Log.Error("No such student {studentDto}", studentDto);
                return false;
            }
            Log.Information("Course updated {studentDto}", studentDto);
            return await _studentRepository.Save();
        }

        public async Task<IEnumerable<CourseBageDto>> GetBages(int id) {
            Log.Information("Getting bages by student id started {id}", id);
            var bages = await _studentRepository.GetBages(id);
            if (bages == null)
            {
                Log.Error("No such student, or no bages on it {id}", id);
                return null;
            }
            List<CourseBageDto> courseBageDtos = new List<CourseBageDto>();
            foreach (CourseBage c in bages)
            {
                courseBageDtos.Add(_mapper.Map<CourseBageDto>(c));
            }
            Log.Information("Bages finded ->{@courseBageDtos}", courseBageDtos);
            return courseBageDtos;
        }

        public async Task<bool> AddBage(BageStudentDto bageStudentDto) {
            Log.Information("Adding bage to student started {bageStudentDto}", bageStudentDto);
            var bageStudent = _mapper.Map<BageStudent>(bageStudentDto);
            if (!await _studentRepository.AddBage(bageStudent))
            {
                Log.Error("Bage didn't add");
                return false;
            }
            Log.Information("Bage add");
            return await _studentRepository.Save();
        }
    }
}
