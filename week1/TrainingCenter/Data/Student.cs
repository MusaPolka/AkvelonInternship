using System.Collections.Generic;

namespace Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalScore { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Lesson> Lesson { get; set; } = new List<Lesson>();
    }
}
