using Microsoft.EntityFrameworkCore;
using Session05.OOConfig.Inheritance;
using System;
using System.Linq;

namespace Session05.OOConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Session05Context();
            //ctx.People.Add(new Student
            //{
            //    FirstName = "A",
            //    LastName = "a",
            //    StudentNumber = "234567"
            //});
            //ctx.People.Add(new Teacher
            //{
            //    FirstName = "B",
            //    LastName = "B",
            //    TeacherNumber = "234567"
            //});
            //ctx.SaveChanges();
            //var p = ctx.People.AsNoTracking().ToList();
            //Console.WriteLine("".PadLeft(100, '-'));

            //var s = ctx.People.AsNoTracking().OfType<Student>().ToList();
            //Console.WriteLine("".PadLeft(100,'-'));
            //var s2 = ctx.Set<Student>().ToList();


            //var t = ctx.People.AsNoTracking().OfType<Teacher>().ToList();
            var nt = ctx.News.AsNoTracking().ToList();
            var nt2 = ctx.News.Include(c=>c.NewsDetail).AsNoTracking().ToList();
            var nd2 = ctx.NewsDetail.AsNoTracking().ToList();
            Console.WriteLine("Hello World!");
        }
    }
}
