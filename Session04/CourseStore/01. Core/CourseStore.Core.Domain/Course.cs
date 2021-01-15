using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseStore.Core.Domain
{
    public class SoftDeletable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class Course
    {
        private readonly ILazyLoader _lazyLoader;

        //public Course(ILazyLoader lazyLoader)
        //{
        //    _lazyLoader = lazyLoader;
        //}
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Discount Discount { get; set; }

        public List<CourseTeacher> Teachers { get; set; }
        public List<Tag> Tags { get; set; }



        private ICollection<Comment> _comments;             //
        public ICollection<Comment> Comments                //
        {
            get
            {
                return _lazyLoader.Load(this, ref _comments);
            }
            set
            {
                _comments = value;
            }

        }

    }
}
