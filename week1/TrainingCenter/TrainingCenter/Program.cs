using BusinessLogic.Contracts;
using BusinessLogic.Services;
using Data;
using System;
using System.Collections.Generic;

namespace TrainingCenter
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ICreateService createService = new CreateService();
            IDeleteService deleteService = new DeleteService();

            //Adding students
            List<Student> students = new List<Student>()
            {
                new Student(){Id = 1, Name = "Musa"},
                new Student(){Id = 2, Name = "Alibek"},
                new Student(){Id = 3, Name = "Ruslan"},
            };

            //Adding courses
            List<Course> courses = new List<Course>()
            {
                new Course(){Id = 1, Name = "HTML and CSS"},
                new Course(){Id = 2, Name = "JavaScript"}
            };

            //Adding lessons
            List<Lesson> HtmlLessons = new List<Lesson>()
            {
                new Lesson(){Id = 1, Name = "First Page", CourseId = 1, Course = courses[0]},
                new Lesson(){Id = 2, Name = "Basic tags", CourseId = 1, Course = courses[0]},
                new Lesson(){Id = 3, Name = "Advanced tags", CourseId = 1, Course = courses[0]}
            };

            List<Lesson> JavaScriptLessons = new List<Lesson>()
            {
                new Lesson(){Id = 1, Name = "Data types", CourseId = 2, Course = courses[1]},
                new Lesson(){Id = 2, Name = "Arrays", CourseId = 2, Course = courses[1]},
                new Lesson(){Id = 3, Name = "if-else statement", CourseId = 2, Course = courses[1]}
            };

            //Adding teachers
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){Id = 1, Name = "Rustem", Courses = { courses[0] } },
                new Teacher(){Id = 2, Name = "Kirill", Courses = { courses[1] } }
            };

            //Adding lessons to our courses
            courses[0].Lessons.AddRange(HtmlLessons);
            courses[1].Lessons.AddRange(JavaScriptLessons);

            //Warking with our services
            createService.AddCourseToStudent(courses[0], students[0]);
            createService.AddCourseToTeacher(courses[0], teachers[1]);

            //Giving score to our students
            students[0].Courses[0].Lessons[0].Score = teachers[0].GiveScore();
            students[0].Courses[0].Score = teachers[0].GiveScore();

            Console.WriteLine($"Lesson score: {students[0].Courses[0].Lessons[0].Score}");
            Console.WriteLine($"Course score: {students[0].Courses[0].Score}");
            Console.WriteLine($"Total score: {students[0].Courses[0].Score}");
        }
    }
}
