using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationTest.Models
{
    public partial class Course
    {
        public Course()
        {
            Comments = new HashSet<Comment>();
            CourseTags = new HashSet<CourseTag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourseTag> CourseTags { get; set; }
    }
}
