using System;
using System.Collections.Generic;

#nullable disable

namespace MigrationTest.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string CommentBy { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
