using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Contracts
{
    public interface IDeleteService
    {
        void DeleteCourseFromStudent(Course course, Student student);
        void DeleteCourseFromTeacher(Course course, Teacher teacher);
    }
}
