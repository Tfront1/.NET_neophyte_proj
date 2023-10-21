using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Models.CourseModel;
using Serilog;

namespace WebApi.Services
{
    public class CourseBageService: ICourseBageService
    {
        private readonly IMapper _mapper;
        private readonly ICourseBageRepository _courseBageRepository;
        public CourseBageService(IMapper mapper, ICourseBageRepository courseBageRepository)
        {
            _mapper = mapper;
            _courseBageRepository = courseBageRepository;
        }

        public async Task<bool> Create(CourseBageDto courseBageDto)
        {
            Log.Information("Creating course bage started {courseBageDto}", courseBageDto);
            _ = courseBageDto ?? throw new ArgumentNullException(nameof(courseBageDto));

            var courseBage = _mapper.Map<CourseBage>(courseBageDto);
            courseBage.Id = default;

            Log.Information("Course bage model {courseBage}", courseBage);
            if (!await _courseBageRepository.Create(courseBage).ConfigureAwait(false))
            {
                Log.Error("Bad reauest data,creating stoped {courseBage}", courseBage);
                return false;
            }
            return await _courseBageRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Log.Information("Deleting course bage by id started {id}", id);
            if (!await _courseBageRepository.Delete(id).ConfigureAwait(false))
            {
                Log.Error("No such course bage with id {id}", id);
                return false;
            }
            Log.Information("Course bage deleted");
            return await _courseBageRepository.Save();
        }

        public async Task<IEnumerable<CourseBageDto>> GetAll()
        {
            Log.Information("Getting all courses bage started");
            var coursesBage = await _courseBageRepository.GetAll();
            List<CourseBageDto> dto = new List<CourseBageDto>();
            foreach (CourseBage c in coursesBage)
            {
                dto.Add(_mapper.Map<CourseBageDto>(c));
            }
            Log.Information("All courses bage ->{@dto}", dto);
            return dto;
        }

        public async Task<IEnumerable<CourseBageDto>> GetByCourseId(int id)
        {
            Log.Information("Getting all courses bage by course id started");
            var coursesBage = await _courseBageRepository.GetByCourseId(id);
            List<CourseBageDto> dto = new List<CourseBageDto>();
            foreach (CourseBage c in coursesBage)
            {
                dto.Add(_mapper.Map<CourseBageDto>(c));
            }
            Log.Information("All courses bage ->{@dto}", dto);
            return dto;
        }

        public async Task<CourseBageDto> GetById(int id)
        {
            Log.Information("Getting course bage by id started {id}", id);
            var courseBage = await _courseBageRepository.GetById(id).ConfigureAwait(false);
            if (courseBage == null)
            {
                Log.Error("No such course bage with id {id}", id);
                return null;
            }
            var courseBageDto = _mapper.Map<CourseBageDto>(courseBage);
            Log.Information("Course bage finded {courseBageDto}", courseBageDto);
            return courseBageDto;
        }

        public async Task<bool> Update(CourseBageDto courseBageDto)
        {
            Log.Information("Updating course bage started {courseBageDto}", courseBageDto);
            _ = courseBageDto ?? throw new ArgumentNullException(nameof(courseBageDto));

            var courseBage = _mapper.Map<CourseBage>(courseBageDto);


            if (!await _courseBageRepository.Update(courseBage).ConfigureAwait(false))
            {
                Log.Error("No such course bage {courseBageDto}", courseBageDto);
                return false;
            }
            Log.Information("Course bage updated {courseBageDto}", courseBageDto);
            return await _courseBageRepository.Save();
        }
    }
}
