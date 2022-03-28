using BusinessLogic.Contracts;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class DeleteService : IDeleteService
    {
        public void DeleteCourseFromStudent(Course course, Student student)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }

            student.Courses.Remove(course);
        }

        public void DeleteCourseFromTeacher(Course course, Teacher teacher)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }

            teacher.Courses.Remove(course);
        }
    }
}
