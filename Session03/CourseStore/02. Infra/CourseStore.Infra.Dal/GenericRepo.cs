using CourseStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Infra.Dal
{
    public static class GenericRepo
    {

        public static void EagerLoading()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var query = ctx.Courses
                .Include(c => c.Comments)
                .Include(c => c.Discount)
                .Include(c => c.Tags)
                .Include(c => c.Teachers.OrderBy(d => d.SortOrder).Take(10)).ThenInclude(c => c.Teacher);
            var queryString = query.ToQueryString();
            var result = query.ToList();
            Console.WriteLine(queryString);

        }
        public static void ExplicitLoading()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var course = ctx.Courses.FirstOrDefault();
            ctx.Entry(course).Reference(c => c.Discount).Load();
            ctx.Entry(course).Collection(c => c.Comments).Load();
            ctx.Entry(course).Collection(c => c.Teachers).Query().Where(c => c.SortOrder < 3);
        }

        public static void SelectLoad()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var result = ctx.Courses.Where(c => c.CourseId > 1).Select(
                c => new
                {
                    c.CourseId,
                    c.Title,
                    commentCount = c.Comments.Count(),
                });
        }

        public static void ClientVsServerWithException()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var result = ctx.Courses.OrderBy(c => c.WithLable).Take(10);
        }
        public static void ClientVsServerWithOK()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var result = ctx.Courses.Select(c => new
            {
                c.Title,
                stringTags = string.Join(',',c.Tags)
            });
        }
        public static void OrderBy()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var list = ctx.Courses.OrderBy(c => c.Price).ThenBy(c=>c.Title);
            var list2 = ctx.Courses.OrderByDescending(c => c.Price).ThenByDescending(c => c.Title);

        }

        public static void Paging()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var page01 = ctx.Courses.Skip(0).Take(10);
            var page02 = ctx.Courses.Skip(10).Take(10);
            var page03 = ctx.Courses.Skip(20).Take(10);
        }
        public static void DbFunctions()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            ctx.Courses.Where(x => EF.Functions.Collate(x.Title, "Latin1_General_CS_AS") == "HELP");
            ctx.Courses.Where(x => EF.Functions.Like(x.Title, "The ___ sat on the %."));

        }

        public static void ObjectState()
        {
            var dbContext = DbContextProvider.GetSqlDbContext();
            var course = new Course
            {
                Title = "Corse 01",
                Description = "Description 01",
                Price = 100
            };

            var state = dbContext.Entry(course).State;
            Console.WriteLine(state);
            Console.WriteLine("".PadLeft(100, '-'));
            dbContext.Entry(course).State = EntityState.Added;
            state = dbContext.Entry(course).State;
            Console.WriteLine(state);

            Console.WriteLine("".PadLeft(100, '-'));



            dbContext.Remove(course);
            state = dbContext.Entry(course).State;
            Console.WriteLine(state);
            Console.WriteLine("".PadLeft(100, '-'));



            dbContext.Add(course);
            state = dbContext.Entry(course).State;
            Console.WriteLine(state);
            Console.WriteLine("".PadLeft(100, '-'));


            var courseDb = dbContext.Courses.FirstOrDefault(c => c.CourseId == 1);
            state = dbContext.Entry(courseDb).State;
            Console.WriteLine(state);
            Console.WriteLine("".PadLeft(100, '-'));


            courseDb.Title = "123";
            state = dbContext.Entry(courseDb).State;
            Console.WriteLine(state);
            Console.WriteLine("".PadLeft(100, '-'));

        }

        public static void Add()
        {
            var dbContext = DbContextProvider.GetSqlDbContext();

            var course = new Course
            {
                Title = "New Course 02",
                Description = "Description New Course 02",
                Price = 100,
                Discount = new Discount
                {
                    NewPrice = 10,
                    Title = "Haraji"
                }
            };
            
            dbContext.Courses.Add(course);
            //dbContext.Add(course);
            dbContext.SaveChanges();
            var stateAfterSaveChange = dbContext.Entry(course).State;
            Console.WriteLine(stateAfterSaveChange);
        }


        public static void Updates()
        {
            var course = Read();
            var newCourse = PartialDisplay(course);
            PartialSave(newCourse);



            var course2 = Read();
            var NewCourseFull = FullDisplay(course2);
            FullSave(NewCourseFull);
        }
        private static void PartialSave(UpdateViewMode partialCourse)
        {
            var dbContext = DbContextProvider.GetSqlDbContext();
            var oldCourseForUpdate = dbContext.Courses.Find(partialCourse.CourseId);

            var temp = dbContext.Courses.FirstOrDefault(c => c.CourseId == 1);
            var temp2 = dbContext.Courses.SingleOrDefault(c => c.CourseId == 1);

            oldCourseForUpdate.Title = partialCourse.Title;
            dbContext.SaveChanges();
        }

        private static UpdateViewMode PartialDisplay(Course course)
        {
            Console.WriteLine($"Id: {course.CourseId} Title: {course.Title}");
            var newCourse = new UpdateViewMode
            {
                Title = "TT",
                CourseId = course.CourseId
            };
            return newCourse;
        }

        private static Course FullDisplay(Course course)
        {
            Console.WriteLine($"Id: {course.CourseId} Title: {course.Title}");
            course.Title = "Full Display Course";
            return course;
        }
        private static void FullSave(Course fullCourse)
        {
            var dbContext = DbContextProvider.GetSqlDbContext();
            dbContext.Courses.Update(fullCourse);
            dbContext.SaveChanges();
        }
        private static Course Read()
        {
            var dbContext = DbContextProvider.GetSqlDbContext();
            return dbContext.Courses.Find(1);
        }
    }
}

