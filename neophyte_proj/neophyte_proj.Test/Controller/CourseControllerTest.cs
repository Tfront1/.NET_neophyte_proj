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


        [Test]
        public async Task GetById_ExistingCourse_200Ok()
        {
            // Arrange
            int courseId = 1;
            var courseDto = new CourseDto{};

            var courseRepository = A.Fake<ICourseRepository>();
            var mapper = A.Fake<IMapper>();

            A.CallTo(() => courseRepository.GetById(A<int>._)).Returns(Task.FromResult(new Course()));
            A.CallTo(() => mapper.Map<CourseDto>(A<Course>._)).Returns(courseDto);

            var courseService = new CourseService(mapper, courseRepository);
            var controller = new CourseController(courseService);

            // Act
            var result = await controller.GetById(courseId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
        [Test]
        public async Task GetById_NonExistentCourse_404NotFound()
        {
            // Arrange
            int courseId = 1;

            var courseRepository = A.Fake<ICourseRepository>();
            var mapper = A.Fake<IMapper>();

            A.CallTo(() => courseRepository.GetById(A<int>._)).Returns(Task.FromResult<Course>(null));

            var courseService = new CourseService(mapper, courseRepository);
            var controller = new CourseController(courseService);

            // Act
            var result = await controller.GetById(courseId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }
        [Test]
        public async Task Create_ValidCourse_201Created()
        {
            // Arrange
            var courseDto = new CourseDto{};

            var courseService = A.Fake<ICourseService>();
            A.CallTo(() => courseService.Create(A<CourseDto>._)).Returns(Task.FromResult(true));

            var controller = new CourseController(courseService);

            // Act
            var result = await controller.Create(courseDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(201);
        }
        [Test]
        public async Task Create_InvalidCourse_400BadRequest()
        {
            // Arrange
            var courseDto = new CourseDto { };

            var courseService = A.Fake<ICourseService>();
            A.CallTo(() => courseService.Create(A<CourseDto>._)).Returns(Task.FromResult(false));

            var controller = new CourseController(courseService);

            // Act
            var result = await controller.Create(courseDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
        }
        [Test]
        public async Task Update_ValidCourse_200OK()
        {
            // Arrange
            var courseDto = new CourseDto{};

            var courseService = A.Fake<ICourseService>();
            A.CallTo(() => courseService.Update(A<CourseDto>._)).Returns(Task.FromResult(true));

            var controller = new CourseController(courseService);

            // Act
            var result = await controller.Update(courseDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
        [Test]
        public async Task Update_InvalidCourse_404NotFound()
        {
            // Arrange
            var courseDto = new CourseDto{};

            var courseService = A.Fake<ICourseService>();
            A.CallTo(() => courseService.Update(A<CourseDto>._)).Returns(Task.FromResult(false)); // Return false to indicate that the course was not found

            var controller = new CourseController(courseService);

            // Act
            var result = await controller.Update(courseDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }

        [Test]
        public async Task Delete_ExistingCourse_200OK()
        {
            // Arrange
            int courseId = 1;

            var courseService = A.Fake<ICourseService>();
            A.CallTo(() => courseService.Delete(courseId)).Returns(Task.FromResult(true));

            var controller = new CourseController(courseService);

            // Act
            var result = await controller.Delete(courseId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task Delete_NonExistingCourse_404NotFound()
        {
            // Arrange
            int courseId = 1;

            var courseService = A.Fake<ICourseService>();
            A.CallTo(() => courseService.Delete(courseId)).Returns(Task.FromResult(false)); // Return false to indicate that the course was not found

            var controller = new CourseController(courseService);

            // Act
            var result = await controller.Delete(courseId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }
    }
}
