using System.Collections.Generic;

namespace CourseStore.Core.Domain
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CourseTeacher> Courses { get; set; }

    }
}
