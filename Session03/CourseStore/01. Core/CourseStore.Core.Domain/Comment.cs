using System;
using System.Collections.Generic;

namespace CourseStore.Core.Domain
{
    public class RootObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Relation01> Relation01s{ get; set; }
        public List<Relation02> Relation02s{ get; set; }
        public List<Relation03> Relation03s { get; set; }
    }
    public class Relation01
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class Relation02
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class Relation03
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string CommentBy { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
