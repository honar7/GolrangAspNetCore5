using Microsoft.EntityFrameworkCore;
using System;

namespace MigrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new MyDbContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            dbContext.Database.Migrate();


            Console.WriteLine("Hello World!");
        }
    }
}
