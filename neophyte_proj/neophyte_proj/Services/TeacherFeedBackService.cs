using AutoMapper;
using DataAccess.Repositories.TeacherRepo.Interfaces;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.DataAccess.Models.TeacherModel;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using Serilog;

namespace WebApi.Services
{
    public class TeacherFeedBackService: ITeacherFeedBackService
    {
        private readonly IMapper _mapper;
        private readonly ITeacherFeedBackRepository _teacherFeedBackRepository;
        public TeacherFeedBackService(IMapper mapper, ITeacherFeedBackRepository teacherFeedBackRepository)
        {
            _mapper = mapper;
            _teacherFeedBackRepository = teacherFeedBackRepository;
        }

        public async Task<bool> Create(TeacherFeedBackDto teacherFeedBackDto)
        {
            Log.Information("Creating teacher feedback started {teacherFeedBackDto}", teacherFeedBackDto);
            _ = teacherFeedBackDto ?? throw new ArgumentNullException(nameof(teacherFeedBackDto));

            var teacherFeedBack = _mapper.Map<TeacherFeedBack>(teacherFeedBackDto);
            teacherFeedBack.Id = default;

            Log.Information("Course teacher model {teacherFeedBack}", teacherFeedBack);
            if (!await _teacherFeedBackRepository.Create(teacherFeedBack).ConfigureAwait(false))
            {
                Log.Error("Bad reauest data,creating stoped {courseFeedBack}", teacherFeedBack);
                return false;
            }
            return await _teacherFeedBackRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Log.Information("Deleting teacher feedback by id started {id}", id);
            if (!await _teacherFeedBackRepository.Delete(id).ConfigureAwait(false))
            {
                Log.Error("No such teacher feedback with id {id}", id);
                return false;
            }
            Log.Information("Teacher feedback deleted");
            return await _teacherFeedBackRepository.Save();
        }

        public async Task<IEnumerable<TeacherFeedBackDto>> GetAll()
        {
            Log.Information("Getting all teachers feedback started");
            var teacherFeedBack = await _teacherFeedBackRepository.GetAll();
            List<TeacherFeedBackDto> dto = new List<TeacherFeedBackDto>();
            foreach (TeacherFeedBack c in teacherFeedBack)
            {
                dto.Add(_mapper.Map<TeacherFeedBackDto>(c));
            }
            Log.Information("All teachers feedback ->{@dto}", dto);
            return dto;
        }

        public async Task<TeacherFeedBackDto> GetById(int id)
        {
            Log.Information("Getting teacher feedback by id started {id}", id);
            var teacherFeedBack = await _teacherFeedBackRepository.GetById(id).ConfigureAwait(false);
            if (teacherFeedBack == null)
            {
                Log.Error("No such teacher feedback with id {id}", id);
                return null;
            }
            var teacherFeedBackDto = _mapper.Map<TeacherFeedBackDto>(teacherFeedBack);
            Log.Information("Teacher feedback finded {teacherFeedBackDto}", teacherFeedBackDto);
            return teacherFeedBackDto;
        }

        public async Task<IEnumerable<TeacherFeedBackDto>> GetByTeacherId(int id)
        {
            Log.Information("Getting all teacher feedback by teacher id started");
            var teacherFeedBack = await _teacherFeedBackRepository.GetByTeacherId(id);
            List<TeacherFeedBackDto> dto = new List<TeacherFeedBackDto>();
            foreach (TeacherFeedBack c in teacherFeedBack)
            {
                dto.Add(_mapper.Map<TeacherFeedBackDto>(c));
            }
            Log.Information("All teacher feedback ->{@dto}", dto);
            return dto;
        }

        public async Task<bool> Update(TeacherFeedBackDto teacherFeedBackDto)
        {
            Log.Information("Updating teacher feedback started {teacherFeedBackDto}", teacherFeedBackDto);
            _ = teacherFeedBackDto ?? throw new ArgumentNullException(nameof(teacherFeedBackDto));

            var teacherFeedBack = _mapper.Map<TeacherFeedBack>(teacherFeedBackDto);


            if (!await _teacherFeedBackRepository.Update(teacherFeedBack).ConfigureAwait(false))
            {
                Log.Error("No such teacher feedback {teacherFeedBackDto}", teacherFeedBackDto);
                return false;
            }
            Log.Information("Course bage updated {teacherFeedBackDto}", teacherFeedBackDto);
            return await _teacherFeedBackRepository.Save();
        }
    }
}
