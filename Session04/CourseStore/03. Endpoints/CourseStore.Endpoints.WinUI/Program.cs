using CourseStore.Core.Domain;
using CourseStore.Infra.Dal;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CourseStore.Endpoints.WinUI
{
   
    class Program
    {
        static void Main(string[] args)
        {

            //TipsAndTricks.NormalRelationshipFixup();
            //TipsAndTricks.AddEmp();
            // TipsAndTricks.LoadEmp();
            //TipsAndTricks.AddRootObject();
            //TipsAndTricks.LoadRootObject(3);

            //var course = new Course
            //{
            //    Title = "Title",
            //    Price = 100,
            //    Description = "Description"
            //};
            var ctx = DbContextProvider.GetSqlDbContext();

            var course = new Course
            {
                CourseId = 1
            };

            ctx.Remove(course);



            var discount = new Discount
            {
                Course = course,
                CourseId = 2,
                Title = "DiscountTitle",
                NewPrice = 10
            };

            ctx.Add(discount);


            ctx.SaveChanges();
            Console.WriteLine("Press Any key");

            Console.ReadLine();
        }

        
    }
}
