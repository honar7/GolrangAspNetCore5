using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationTest.Models
{
    public partial class CourseTag
    {
        public int CoursesId { get; set; }
        public int TagsId { get; set; }

        public virtual Course Courses { get; set; }
        public virtual Tag Tags { get; set; }
    }
}
