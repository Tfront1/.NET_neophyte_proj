using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Controllers;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModel;
using neophyte_proj.WebApi.Models.TeacherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Services;

namespace neophyte_proj.Test.Controller
{
    public class TeacherControllerTest
    {
        [Test]
        public async Task Create_ValidTeacher_200OK()
        {
            // Arrange
            var teacherDto = new TeacherDto{};

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.Create(A<TeacherDto>._)).Returns(Task.FromResult(true));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.Create(teacherDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task Create_InvalidTeacher_400BadRequest()
        {
            // Arrange
            var teacherDto = new TeacherDto{};

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.Create(A<TeacherDto>._)).Returns(Task.FromResult(false));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.Create(teacherDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
        }
        [Test]
        public async Task GetById_ExistingTeacher_200OK()
        {
            // Arrange
            int teacherId = 1;

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.GetById(teacherId)).Returns(Task.FromResult(new TeacherDto()));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.GetById(teacherId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetById_NonExistingTeacher_404NotFound()
        {
            // Arrange
            int teacherId = 1;

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.GetById(teacherId)).Returns(Task.FromResult((TeacherDto)null));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.GetById(teacherId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }
        [Test]
        public async Task Delete_ExistingTeacher_200OK()
        {
            // Arrange
            int teacherId = 1;

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.Delete(teacherId)).Returns(Task.FromResult(true));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.Delete(teacherId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task Delete_NonExistingTeacher_404NotFound()
        {
            // Arrange
            int teacherId = 1;

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.Delete(teacherId)).Returns(Task.FromResult(false));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.Delete(teacherId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }
        [Test]
        public async Task Update_ValidTeacher_200OK()
        {
            // Arrange
            var teacherDto = new TeacherDto
            {
                // Ініціалізувати TeacherDto за потреби
            };

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.Update(A<TeacherDto>._)).Returns(Task.FromResult(true));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.Update(teacherDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task Update_InvalidTeacher_404NotFound()
        {
            // Arrange
            var teacherDto = new TeacherDto{};

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.Update(A<TeacherDto>._)).Returns(Task.FromResult(false));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.Update(teacherDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }
        [Test]
        public async Task GetAll_ReturnsListOfTeachers_200OK()
        {
            // Arrange
            var teacherService = A.Fake<ITeacherService>();
            var teacherList = new List<TeacherDto>{};
            A.CallTo(() => teacherService.GetAll()).Returns(teacherList);

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.GetAll() as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetCourses_ExistingCourses_200OK()
        {
            // Arrange
            int teacherId = 1;

            var teacherService = A.Fake<ITeacherService>();
            var courseList = new List<CourseDto>{};
            A.CallTo(() => teacherService.GetCourses(teacherId)).Returns(courseList);

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.GetCourses(teacherId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
        [Test]
        public async Task AddCourse_ValidCourseTeacherDto_200OK()
        {
            // Arrange
            var courseTeacherDto = new CourseTeacherDto{};

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.AddCourse(A<CourseTeacherDto>._)).Returns(Task.FromResult(true));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.AddCourse(courseTeacherDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task AddCourse_InvalidCourseTeacherDto_404NotFound()
        {
            // Arrange
            var courseTeacherDto = new CourseTeacherDto{};

            var teacherService = A.Fake<ITeacherService>();
            A.CallTo(() => teacherService.AddCourse(A<CourseTeacherDto>._)).Returns(Task.FromResult(false));

            var controller = new TeacherController(teacherService);

            // Act
            var result = await controller.AddCourse(courseTeacherDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }


    }
}
