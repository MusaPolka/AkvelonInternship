using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Contracts
{
    public interface ICreateService
    {
        void AddCourseToStudent(Course course, Student student);
        void AddCourseToTeacher(Course course, Teacher teacher);
    }
}
