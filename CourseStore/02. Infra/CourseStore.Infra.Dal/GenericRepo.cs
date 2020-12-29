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
    }
}

