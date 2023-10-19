using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using neophyte_proj.WebApi.Controllers;
using neophyte_proj.WebApi.Models.CourseModel;
using neophyte_proj.WebApi.Models.IntermediateModel;
using neophyte_proj.WebApi.Models.StudentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Services;

namespace neophyte_proj.Test.Controller
{
    public class StudentControllerTest
    {
        [Test]
        public async Task Create_ValidStudent_201Created()
        {
            // Arrange
            var studentDto = new StudentDto{};

            var studentService = A.Fake<IStudentService>();
            A.CallTo(() => studentService.Create(A<StudentDto>._)).Returns(Task.FromResult(true));

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.Create(studentDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(201);
        }
        [Test]
        public async Task Create_InvalidStudent_400BadRequest()
        {
            // Arrange
            var studentDto = new StudentDto{};

            var studentService = A.Fake<IStudentService>();
            A.CallTo(() => studentService.Create(A<StudentDto>._)).Returns(Task.FromResult(false));

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.Create(studentDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
        }
        [Test]
        public async Task Update_ValidStudent_200OK()
        {
            // Arrange
            var studentDto = new StudentDto{};

            var studentService = A.Fake<IStudentService>();
            A.CallTo(() => studentService.Update(A<StudentDto>._)).Returns(Task.FromResult(true));

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.Update(studentDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
        [Test]
        public async Task Update_InvalidStudent_404NotFound()
        {
            // Arrange
            var studentDto = new StudentDto{};

            var studentService = A.Fake<IStudentService>();
            A.CallTo(() => studentService.Update(A<StudentDto>._)).Returns(Task.FromResult(false));

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.Update(studentDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }
        [Test]
        public async Task Delete_ExistingStudent_200OK()
        {
            // Arrange
            int studentId = 1;

            var studentService = A.Fake<IStudentService>();
            A.CallTo(() => studentService.Delete(studentId)).Returns(Task.FromResult(true));

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.Delete(studentId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
        [Test]
        public async Task Delete_NonExistingStudent_404NotFound()
        {
            // Arrange
            int studentId = 1;

            var studentService = A.Fake<IStudentService>();
            A.CallTo(() => studentService.Delete(studentId)).Returns(Task.FromResult(false));

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.Delete(studentId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }

        [Test]
        public async Task GetAll_ReturnsListOfStudents_200OK()
        {
            // Arrange
            var studentService = A.Fake<IStudentService>();
            var studentList = new List<StudentDto>{};
            A.CallTo(() => studentService.GetAll()).Returns(studentList);

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.GetAll() as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetCourses_ReturnsListOfCourses_200OK()
        {
            // Arrange
            int studentId = 1;

            var studentService = A.Fake<IStudentService>();
            var courseList = new List<CourseDto>{};
            A.CallTo(() => studentService.GetCourses(studentId)).Returns(courseList);

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.GetCourses(studentId) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task AddCourse_ValidCourseStudentDto_200OK()
        {
            // Arrange
            var courseStudentDto = new CourseStudentDto{};

            var studentService = A.Fake<IStudentService>();
            A.CallTo(() => studentService.AddCourse(A<CourseStudentDto>._)).Returns(Task.FromResult(true));

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.AddCourse(courseStudentDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
        [Test]
        public async Task AddCourse_InvalidCourseStudentDto_404NotFound()
        {
            // Arrange
            var courseStudentDto = new CourseStudentDto{};

            var studentService = A.Fake<IStudentService>();
            A.CallTo(() => studentService.AddCourse(A<CourseStudentDto>._)).Returns(Task.FromResult(false));

            var controller = new StudentController(studentService);

            // Act
            var result = await controller.AddCourse(courseStudentDto) as JsonResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }

    }
}
