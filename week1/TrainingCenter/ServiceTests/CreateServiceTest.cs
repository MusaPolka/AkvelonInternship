using BusinessLogic.Contracts;
using BusinessLogic.Services;
using Data;
using System;
using Xunit;

namespace ServiceTests
{
    public class CreateServiceTest
    {
        ICreateService createService = new CreateService();

        [Fact]
        public void AddCourseToStudent_ShouldAddCourse()
        {
            Student student = new Student() { Name = "Andrew"};
            Course course = new Course() { Name = "Angular" };

            createService.AddCourseToStudent(course, student);

            Assert.True(student.Courses[0] == course);
        }
        [Theory]
        [InlineData("Andrew", null)]
        public void AddCourseToStudent_ShouldFail(string name, Course course)
        {
            Student student = new Student() { Name = name };

            Assert.Throws<ArgumentNullException>(() => createService.AddCourseToStudent(course, student));
        }


        [Fact]
        public void AddCourseToTeacher_ShouldAddCourse()
        {
            Teacher teacher = new Teacher() { Name = "Pavel" };
            Course course = new Course() { Name = "Java" };

            createService.AddCourseToTeacher(course, teacher);

            Assert.True(teacher.Courses[0] == course);
        }

        [Theory]
        [InlineData("Pavel", null)]
        public void AddCourseToTeacher_ShouldFail(string name, Course course)
        {
            Teacher teacher = new Teacher() { Name = name };

            Assert.Throws<ArgumentNullException>(() => createService.AddCourseToTeacher(course, teacher));
        }
    }
}
