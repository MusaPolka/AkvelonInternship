using BusinessLogic.Contracts;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CreateService : ICreateService
    {
        public void AddCourseToStudent(Course course, Student student)
        {
            if (course == null)
            {
                throw new ArgumentNullException();  
            }

            student.Courses.Add(course);
        }

        public void AddCourseToTeacher(Course course, Teacher teacher)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }

            teacher.Courses.Add(course);
        }
    }
}
