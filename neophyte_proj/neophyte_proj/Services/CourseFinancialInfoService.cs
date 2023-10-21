using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Models.CourseModel;
using Serilog;

namespace WebApi.Services
{
    public class CourseFinancialInfoService:ICourseFinancialInfoService
    {
        private readonly IMapper _mapper;
        private readonly ICourseFinancialInfoRepository _courseFinancialInfoRepository;
        public CourseFinancialInfoService(IMapper mapper, ICourseFinancialInfoRepository courseFinancialInfoRepository)
        {
            _mapper = mapper;
            _courseFinancialInfoRepository = courseFinancialInfoRepository;
        }

        public async Task<bool> Create(CourseFinancialInfoDto dto)
        {
            Log.Information("Creating course financial info started {dto}", dto);
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var courseFinancialInfo = _mapper.Map<CourseFinancialInfo>(dto);
            courseFinancialInfo.Id = default;

            Log.Information("Course financial info model {courseFinancialInfo}", courseFinancialInfo);
            if (!await _courseFinancialInfoRepository.Create(courseFinancialInfo).ConfigureAwait(false))
            {
                Log.Error("Bad reauest data,creating stoped {courseFinancialInfo}", courseFinancialInfo);
                return false;
            }
            return await _courseFinancialInfoRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Log.Information("Deleting course financial info by id started {id}", id);
            if (!await _courseFinancialInfoRepository.Delete(id).ConfigureAwait(false))
            {
                Log.Error("No such course financial info with id {id}", id);
                return false;
            }
            Log.Information("Course financial info deleted");
            return await _courseFinancialInfoRepository.Save();
        }

        public async Task<IEnumerable<CourseFinancialInfoDto>> GetAll()
        {
            Log.Information("Getting all courses financial info started");
            var coursesFinancialInfo = await _courseFinancialInfoRepository.GetAll();
            List<CourseFinancialInfoDto> dto = new List<CourseFinancialInfoDto>();
            foreach (CourseFinancialInfo c in coursesFinancialInfo)
            {
                dto.Add(_mapper.Map<CourseFinancialInfoDto>(c));
            }
            Log.Information("All courses financial info ->{@dto}", dto);
            return dto;
        }

        public async Task<CourseFinancialInfoDto> GetByCourseId(int id)
        {
            Log.Information("Getting course financial info by course id started {id}", id);
            var courseFinancialInfo = await _courseFinancialInfoRepository.GetByCourseId(id).ConfigureAwait(false);
            if (courseFinancialInfo == null)
            {
                Log.Error("No such course financial info with course id {id}", id);
                return null;
            }
            var courseFinancialInfoDto = _mapper.Map<CourseFinancialInfoDto>(courseFinancialInfo);
            Log.Information("Course financial info finded {courseFinancialInfoDto}", courseFinancialInfoDto);
            return courseFinancialInfoDto;
        }

        public async Task<CourseFinancialInfoDto> GetById(int id)
        {
            Log.Information("Getting course financial info by id started {id}", id);
            var courseFinancialInfo = await _courseFinancialInfoRepository.GetById(id).ConfigureAwait(false);
            if (courseFinancialInfo == null)
            {
                Log.Error("No such course financial info with id {id}", id);
                return null;
            }
            var courseFinancialInfoDto = _mapper.Map<CourseFinancialInfoDto>(courseFinancialInfo);
            Log.Information("Course financial info finded {courseFinancialInfoDto}", courseFinancialInfoDto);
            return courseFinancialInfoDto;
        }

        public async Task<bool> Update(CourseFinancialInfoDto dto)
        {
            Log.Information("Updating course financial info started {dto}", dto);
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var courseFinancialInfo = _mapper.Map<CourseFinancialInfo>(dto);

            if (!await _courseFinancialInfoRepository.Update(courseFinancialInfo).ConfigureAwait(false))
            {
                Log.Error("No such course financial info {dto}", dto);
                return false;
            }
            Log.Information("Course financial info updated {dto}", dto);
            return await _courseFinancialInfoRepository.Save();
        }
    }
}
