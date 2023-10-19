using AutoMapper;
using DataAccess.Repositories.CourseRepo.Interfaces;
using DataAccess.Repositories.CourseRepo.Repos;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using neophyte_proj.DataAccess.Context;
using neophyte_proj.DataAccess.Models.CourseModel;
using neophyte_proj.WebApi.Controllers;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neophyte_proj.Test.Controller
{
    public class CourseControllerTest
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly NeophyteApplicationContext _context;
        public CourseControllerTest()
        {
            _context = A.Fake<NeophyteApplicationContext>();
            _courseRepository = new CourseRepository(_context);
            _mapper = A.Fake<IMapper>();
            
        }

        [Test]
        public void CourseController_GetCourseById_Ok() {
            //Arrange
            var courseCourseGeneralInfo = A.Fake<CourseGeneralInfo>();
            var courseDto = A.Fake<CourseDto>();
            A.CallTo(() => _mapper.Map<CourseDto>(courseCourseGeneralInfo)).Returns(courseDto);
            var courseService = new CourseService(_mapper, _courseRepository);
            var controller = new CourseController(courseService);

            //Act
            var result = controller.GetById(1);
            //Assert
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
