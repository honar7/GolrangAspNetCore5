using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseStore.Core.Domain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        //public virtual Discount Discount { get; set; }
        //public virtual List<Comment> Comments { get; set; }
        //public virtual List<CourseTeacher> Teachers { get; set; }
        //public virtual List<Tag> Tags { get; set; }

        [NotMapped]
        public string WithLable
        {
            get
            {
                return $"Title: {Title}";
            }
        }
        public virtual Discount Discount { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<CourseTeacher> Teachers { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
