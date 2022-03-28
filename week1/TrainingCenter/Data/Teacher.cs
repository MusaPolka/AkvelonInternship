using System;
using System.Collections.Generic;


namespace Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course> ();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public int GiveScore()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }
    }
}
