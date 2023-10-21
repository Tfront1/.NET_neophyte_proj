using AutoMapper;
using DataAccess.Repositories.StudentRepo.Interfaces;
using DataAccess.Repositories.TeacherRepo.Interfaces;
using DataAccess.Repositories.TeacherRepo.Repos;
using neophyte_proj.DataAccess.Models.StudentModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.StudentModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using Serilog;

namespace WebApi.Services
{
    public class StudentAccountInfoService: IStudentAccountInfoService
    {
        private readonly IMapper _mapper;
        private readonly IStudentAccountInfoRepository _studentAccountInfoRepository;
        public StudentAccountInfoService(IMapper mapper, IStudentAccountInfoRepository studentAccountInfoRepository)
        {
            _mapper = mapper;
            _studentAccountInfoRepository = studentAccountInfoRepository;
        }

        public async Task<bool> Create(StudentAccountInfoDto dto)
        {
            Log.Information("Creating student account info started {dto}", dto);
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var studentAccountInfo = _mapper.Map<StudentAccountInfo>(dto);
            studentAccountInfo.Id = default;

            Log.Information("Student account info model {studentAccountInfo}", studentAccountInfo);
            if (!await _studentAccountInfoRepository.Create(studentAccountInfo).ConfigureAwait(false))
            {
                Log.Error("Bad reauest data,creating stoped {studentAccountInfo}", studentAccountInfo);
                return false;
            }
            return await _studentAccountInfoRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Log.Information("Deleting student account info by id started {id}", id);
            if (!await _studentAccountInfoRepository.Delete(id).ConfigureAwait(false))
            {
                Log.Error("No such student account info with id {id}", id);
                return false;
            }
            Log.Information("Student account info deleted");
            return await _studentAccountInfoRepository.Save();
        }

        public async Task<IEnumerable<StudentAccountInfoDto>> GetAll()
        {
            Log.Information("Getting all students account info started");
            var studentAccountInfo = await _studentAccountInfoRepository.GetAll();
            List<StudentAccountInfoDto> dto = new List<StudentAccountInfoDto>();
            foreach (StudentAccountInfo c in studentAccountInfo)
            {
                dto.Add(_mapper.Map<StudentAccountInfoDto>(c));
            }
            Log.Information("All students account info ->{@dto}", dto);
            return dto;
        }

        public async Task<StudentAccountInfoDto> GetById(int id)
        {
            Log.Information("Getting student account info by id started {id}", id);
            var studentAccountInfo = await _studentAccountInfoRepository.GetById(id).ConfigureAwait(false);
            if (studentAccountInfo == null)
            {
                Log.Error("No such student account info with id {id}", id);
                return null;
            }
            var studentAccountInfoDto = _mapper.Map<StudentAccountInfoDto>(studentAccountInfo);
            Log.Information("Student account info finded {studentAccountInfoDto}", studentAccountInfoDto);
            return studentAccountInfoDto;
        }

        public async Task<StudentAccountInfoDto> GetByStudentId(int id)
        {
            Log.Information("Getting student account info by student id started {id}", id);
            var studentAccountInfo = await _studentAccountInfoRepository.GetByStudentId(id).ConfigureAwait(false);
            if (studentAccountInfo == null)
            {
                Log.Error("No such student account info with started id {id}", id);
                return null;
            }
            var studentAccountInfoDto = _mapper.Map<StudentAccountInfoDto>(studentAccountInfo);
            Log.Information("Student account info finded {studentAccountInfoDto}", studentAccountInfoDto);
            return studentAccountInfoDto;
        }

        public async Task<bool> Update(StudentAccountInfoDto dto)
        {
            Log.Information("Updating student account info started {dto}", dto);
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var studentAccountInfo = _mapper.Map<StudentAccountInfo>(dto);

            if (!await _studentAccountInfoRepository.Update(studentAccountInfo).ConfigureAwait(false))
            {
                Log.Error("No such student account info {dto}", dto);
                return false;
            }
            Log.Information("Student account info updated {dto}", dto);
            return await _studentAccountInfoRepository.Save();
        }
    }
}
