using System.Linq;
using System;
using CourseStore.Core.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.Infra.Dal
{
    public static class TipsAndTricks
    {
        public static void NormalRelationshipFixup()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var course = ctx.Courses.FirstOrDefault(c => c.CourseId == 1);
            var discount = ctx.Comments.FirstOrDefault(c => c.CommentId == 2);
            Console.ReadKey();
        }

        public static void AddEmp()
        {
            var emp = new Employee
            {
                FirstName = "E01",
                LastName = "E01",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                         FirstName = "E02",
                          LastName = "E02",
                          Employees = new List<Employee>
                          {
                              new Employee
                              {
                                  FirstName = "E04",
                                  LastName = "E04",
                              },
                              new Employee
                              {
                                  FirstName = "E05",
                                  LastName = "E05",
                                  Employees = new List<Employee>
                                  {
                                      new Employee
                                      {
                                          FirstName = "E06",
                                          LastName = "E06",
                                      }
                                  }
                              }
                          }
                    },
                   new  Employee{
                         FirstName = "E03",
                         LastName = "E03",
                    }
                }
            };
            var ctx = DbContextProvider.GetSqlDbContext();
            ctx.Employees.Add(emp);
            ctx.SaveChanges();
        }

        public static void LoadEmp()
        {

            var ctx = DbContextProvider.GetSqlDbContext();
          
            var emplist = ctx.Employees.Include(c => c.Employees).ToList();
        }

        public static void AddRootObject()
        {
            var obj = new RootObject
            {
                Title = "Title01",
                Relation01s = new List<Relation01>(),
                Relation02s = new List<Relation02>(),
                Relation03s = new List<Relation03>()
            };
            for (int i = 0; i < 300; i++)
            {
                obj.Relation01s.Add(new Relation01
                {
                    Title = $"t {i}"
                });
                obj.Relation02s.Add(new Relation02
                {
                    Title = $"t {i}"
                });
                obj.Relation03s.Add(new Relation03
                {
                    Title = $"t {i}"
                });
            }

            var ctx = DbContextProvider.GetSqlDbContext();
            ctx.Add(obj);
            ctx.SaveChanges();
        }

        public static void LoadRootObject(int id)
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var query = ctx.RootObjects.AsSplitQuery().
                Include(c => c.Relation01s).
                Include(c => c.Relation02s).
                Include(c => c.Relation03s).ToQueryString();
            var obj = ctx.RootObjects.AsSplitQuery().
                Include(c => c.Relation01s).
                Include(c => c.Relation02s).
                Include(c => c.Relation03s).FirstOrDefault(c=>c.Id == id);


        }

        public static void DetacheObject01()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var obj = ctx.RootObjects.AsSplitQuery().
               Include(c => c.Relation01s).
               Include(c => c.Relation02s).
               Include(c => c.Relation03s).FirstOrDefault(c => c.Id == 1);

            var emp = ctx.Employees.ToList();

            ctx.ChangeTracker.Clear();

        }
        public static void DetacheObject02()
        {
            var ctx = DbContextProvider.GetSqlDbContext();
            var emp = ctx.Employees.ToList();
            var obj = new RootObject();
            using (var ctxtemp = DbContextProvider.GetSqlDbContext())
            {
                obj = ctxtemp.RootObjects.AsSplitQuery().
               Include(c => c.Relation01s).
               Include(c => c.Relation02s).
               Include(c => c.Relation03s).FirstOrDefault(c => c.Id == 1);
            }

        }
    }
}

