using System.Collections.Generic;


namespace Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
