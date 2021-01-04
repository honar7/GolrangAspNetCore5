using System;

namespace CourseStore.Core.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string CommentBy { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
