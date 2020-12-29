using HelloEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEF.DAL
{
    public static class DataClass
    {
        public static void Init()
        {
            using var ctx = new CourseDbContext();
            ctx.Database.EnsureCreated();
        }
        public static void AddCourse(string title)
        {
            using var ctx = new CourseDbContext();
            var course = new Course
            {
                Title = title
            };

            ctx.Add(course);
            ctx.SaveChanges();
        }

        public static void AddTeacher(int courseId,string firstName,string lastName)
        {
            using var ctx = new CourseDbContext();
            var course = ctx.Courses.FirstOrDefault(c => c.CourseId == courseId);
            course.Teachers.Add(new Teacher
            {
                FirstName = firstName,
                LastName = lastName
            }) ;

            ctx.SaveChanges();
        }

        public static void Edit(int courseId, string newTitle)
        {
            using var ctx = new CourseDbContext();
            var course = ctx.Courses.FirstOrDefault(c => c.CourseId == courseId);
            course.Title = newTitle;
            ctx.SaveChanges();
        }

        public static void ReadAllCourse()
        {
            using var ctx = new CourseDbContext();
            var list = ctx.Courses.Include(c => c.Teachers).AsNoTracking().ToList();
            foreach (var course in list)
            {
                Console.WriteLine($"{course.CourseId} {course.Title} {string.Join(',',course.Teachers.Select(c=>c.LastName))}");
            }
        }
    }
}
