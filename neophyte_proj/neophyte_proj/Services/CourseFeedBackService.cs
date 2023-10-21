using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Models.CourseModel;
using Serilog;

namespace WebApi.Services
{
    public class CourseFeedBackService: ICourseFeedBackService
    {
        private readonly IMapper _mapper;
        private readonly ICourseFeedBackRepository _courseFeedBackRepository;
        public CourseFeedBackService(IMapper mapper, ICourseFeedBackRepository courseFeedBackRepository)
        {
            _mapper = mapper;
            _courseFeedBackRepository = courseFeedBackRepository;
        }

        public async Task<bool> Create(CourseFeedBackDto courseFeedBackDto)
        {
            Log.Information("Creating course feedback started {courseFeedBackDto}", courseFeedBackDto);
            _ = courseFeedBackDto ?? throw new ArgumentNullException(nameof(courseFeedBackDto));

            var courseFeedBack = _mapper.Map<CourseFeedBack>(courseFeedBackDto);
            courseFeedBack.Id = default;

            Log.Information("Course feedback model {courseFeedBack}", courseFeedBack);
            if (!await _courseFeedBackRepository.Create(courseFeedBack).ConfigureAwait(false))
            {
                Log.Error("Bad reauest data,creating stoped {courseFeedBack}", courseFeedBack);
                return false;
            }
            return await _courseFeedBackRepository.Save();
        }

        public async Task<bool> Delete(int id)
        {
            Log.Information("Deleting course feedback by id started {id}", id);
            if (!await _courseFeedBackRepository.Delete(id).ConfigureAwait(false))
            {
                Log.Error("No such course feedback with id {id}", id);
                return false;
            }
            Log.Information("Course feedback deleted");
            return await _courseFeedBackRepository.Save();
        }

        public async Task<IEnumerable<CourseFeedBackDto>> GetAll()
        {
            Log.Information("Getting all courses feedback started");
            var coursesFeedback = await _courseFeedBackRepository.GetAll();
            List<CourseFeedBackDto> dto = new List<CourseFeedBackDto>();
            foreach (CourseFeedBack c in coursesFeedback)
            {
                dto.Add(_mapper.Map<CourseFeedBackDto>(c));
            }
            Log.Information("All courses feedback ->{@dto}", dto);
            return dto;
        }

        public async Task<IEnumerable<CourseFeedBackDto>> GetByCourseId(int id)
        {
            Log.Information("Getting all courses feedback by course id started");
            var coursesFeedback = await _courseFeedBackRepository.GetByCourseId(id);
            List<CourseFeedBackDto> dto = new List<CourseFeedBackDto>();
            foreach (CourseFeedBack c in coursesFeedback)
            {
                dto.Add(_mapper.Map<CourseFeedBackDto>(c));
            }
            Log.Information("All courses feedback ->{@dto}", dto);
            return dto;
        }

        public async Task<CourseFeedBackDto> GetById(int id)
        {
            Log.Information("Getting course feedback by id started {id}", id);
            var coursesFeedback = await _courseFeedBackRepository.GetById(id).ConfigureAwait(false);
            if (coursesFeedback == null)
            {
                Log.Error("No such course feedback with id {id}", id);
                return null;
            }
            var coursesFeedbackDto = _mapper.Map<CourseFeedBackDto>(coursesFeedback);
            Log.Information("Course feedback finded {coursesFeedbackDto}", coursesFeedbackDto);
            return coursesFeedbackDto;
        }

        public async Task<bool> Update(CourseFeedBackDto courseFeedBackDto)
        {
            Log.Information("Updating course feedback started {courseFeedBackDto}", courseFeedBackDto);
            _ = courseFeedBackDto ?? throw new ArgumentNullException(nameof(courseFeedBackDto));

            var coursesFeedback = _mapper.Map<CourseFeedBack>(courseFeedBackDto);


            if (!await _courseFeedBackRepository.Update(coursesFeedback).ConfigureAwait(false))
            {
                Log.Error("No such course feedback {courseFeedBackDto}", courseFeedBackDto);
                return false;
            }
            Log.Information("Course bage updated {courseFeedBackDto}", courseFeedBackDto);
            return await _courseFeedBackRepository.Save();
        }
    }
}
