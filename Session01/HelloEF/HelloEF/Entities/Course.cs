using System.Collections.Generic;

namespace HelloEF.Entities
{
    public class Course
    {
        
        public int CourseId { get; set; }
        public string Title { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

    }
}
