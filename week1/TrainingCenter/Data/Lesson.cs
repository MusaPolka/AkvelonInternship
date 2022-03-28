using System.Collections.Generic;

namespace Data
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = new Course();
    }
}
