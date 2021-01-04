using CourseStore.Core.Domain;
using CourseStore.Infra.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CourseStore.Endpoints.WinUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Course
            {
                Price = 100,
                Title = "12",
            };
            var dis = new Discount
            {
                NewPrice = 100,
                Title = "ee"
            };

            //c.Discount = dis;



            var ctx = DbContextProvider.GetSqlDbContext();

            var course = ctx.Courses.Include(c=>c.Discount).Single(c => c.CourseId == 1);
            course.Discount = dis;
            ctx.Add(dis);
            var status = ctx.Entry(course).State;
            //var status2 = ctx.Entry(course.Discount).State;

            course.Discount = new Core.Domain.Discount
            {
                NewPrice = 10,
                Title = "Title"
            };
             status = ctx.Entry(course).State;
             var status2 = ctx.Entry(course.Discount).State;

            Console.ReadLine();
            Console.WriteLine("Press Any key");
        }
    }
}
