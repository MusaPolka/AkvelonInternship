using BusinessLogic.Contracts;
using BusinessLogic.Services;
using Data;
using System;
using Xunit;

namespace ServiceTests
{
    public class DeleteServiceTest
    {
        IDeleteService deleteService = new DeleteService();

        [Fact]
        public void DeleteCourseFromStudent_ShouldDeleteCourse()
        {
            Course course = new Course() { Name = "Angular" };
            Student student = new Student() { Name = "Andrew", Courses = { course } };

            deleteService.DeleteCourseFromStudent(course, student);

            Assert.True(student.Courses.Count == 0);
        }
        [Theory]
        [InlineData("Andrew", null)]
        public void DeleteCourseFromStudent_ShouldFail(string name, Course course)
        {
            Student student = new Student() { Name = name };

            Assert.Throws<ArgumentNullException>(() => deleteService.DeleteCourseFromStudent(course, student));
        }


        [Fact]
        public void DeleteCourseFromTeacher_ShouldAddCourse()
        {
            Course course = new Course() { Name = "Angular" };
            Teacher teacher = new Teacher() { Name = "Ruslan", Courses = { course } };

            deleteService.DeleteCourseFromTeacher(course, teacher);

            Assert.True(teacher.Courses.Count == 0);
        }

        [Theory]
        [InlineData("Ruslan", null)]
        public void DeleteCourseFromTeacher_ShouldFail(string name, Course course)
        {
            Teacher teacher = new Teacher() { Name = name };

            Assert.Throws<ArgumentNullException>(() => deleteService.DeleteCourseFromTeacher(course, teacher));
        }
    }
}
