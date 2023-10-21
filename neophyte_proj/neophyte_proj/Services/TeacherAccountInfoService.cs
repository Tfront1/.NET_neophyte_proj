using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using DataAccess.Repositories.TeacherRepo.Interfaces;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using Serilog;

namespace WebApi.Services
{
    public class TeacherAccountInfoService:ITeacherAccountInfoService
    {
        private readonly IMapper _mapper;
        private readonly ITeacherAccountInfoRepository _teacherAccountInfoRepository;
        public TeacherAccountInfoService(IMapper mapper, ITeacherAccountInfoRepository teacherAccountInfoRepository)
        {
            _mapper = mapper;
            _teacherAccountInfoRepository = teacherAccountInfoRepository;
        }

        public async Task<bool> Create(TeacherAccountInfoDto dto)
        {
            Log.Information("Creating teacher account info started {dto}", dto);
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var teacherAccountInfo = _mapper.Map<TeacherAccountInfo>(dto);
            teacherAccountInfo.Id = default;

            Log.Information("Teacher account info model {teacherAccountInfo}", teacherAccountInfo);
            if (!await _teacherAccountInfoRepository.Create(teacherAccountInfo).ConfigureAwait(false))
            {
                Log.Error("Bad reauest data,creating stoped {teacherAccountInfo}", teacherAccountInfo);
                return false;
            }
            return await _teacherAccountInfoRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Log.Information("Deleting teacher account info by id started {id}", id);
            if (!await _teacherAccountInfoRepository.Delete(id).ConfigureAwait(false))
            {
                Log.Error("No such teacher account info with id {id}", id);
                return false;
            }
            Log.Information("Teacher account info deleted");
            return await _teacherAccountInfoRepository.Save();
        }

        public async Task<IEnumerable<TeacherAccountInfoDto>> GetAll()
        {
            Log.Information("Getting all teachers account info started");
            var teacherAccountInfo = await _teacherAccountInfoRepository.GetAll();
            List<TeacherAccountInfoDto> dto = new List<TeacherAccountInfoDto>();
            foreach (TeacherAccountInfo c in teacherAccountInfo)
            {
                dto.Add(_mapper.Map<TeacherAccountInfoDto>(c));
            }
            Log.Information("All teachers account info ->{@dto}", dto);
            return dto;
        }

        public async Task<TeacherAccountInfoDto> GetById(int id)
        {
            Log.Information("Getting teacher account info by id started {id}", id);
            var teacherAccountInfo = await _teacherAccountInfoRepository.GetById(id).ConfigureAwait(false);
            if (teacherAccountInfo == null)
            {
                Log.Error("No such teacher account info with id {id}", id);
                return null;
            }
            var teacherAccountInfoDto = _mapper.Map<TeacherAccountInfoDto>(teacherAccountInfo);
            Log.Information("Teacher account info finded {teacherAccountInfoDto}", teacherAccountInfoDto);
            return teacherAccountInfoDto;
        }

        public async Task<TeacherAccountInfoDto> GetByTeacherId(int id)
        {
            Log.Information("Getting teacher account info by teacher id started {id}", id);
            var teacherAccountInfo = await _teacherAccountInfoRepository.GetByTeacherId(id).ConfigureAwait(false);
            if (teacherAccountInfo == null)
            {
                Log.Error("No such teacher account info with started id {id}", id);
                return null;
            }
            var teacherAccountInfoDto = _mapper.Map<TeacherAccountInfoDto>(teacherAccountInfo);
            Log.Information("Teacher account info finded {teacherAccountInfoDto}", teacherAccountInfoDto);
            return teacherAccountInfoDto;
        }

        public async Task<bool> Update(TeacherAccountInfoDto dto)
        {
            Log.Information("Updating teacher account info started {dto}", dto);
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var teacherAccountInfo = _mapper.Map<TeacherAccountInfo>(dto);

            if (!await _teacherAccountInfoRepository.Update(teacherAccountInfo).ConfigureAwait(false))
            {
                Log.Error("No such teacher account info {dto}", dto);
                return false;
            }
            Log.Information("Teacher account info updated {dto}", dto);
            return await _teacherAccountInfoRepository.Save();
        }
    }
}
