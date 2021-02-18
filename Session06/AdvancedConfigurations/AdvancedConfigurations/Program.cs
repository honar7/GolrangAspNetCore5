using System;
using System.Linq;

namespace AdvancedConfigurations
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new MyDbContext();

            //var person = dbContext.People.Where(c => MyFunctions.GetMaxAge(10) > c.Age);

            //dbContext.People.Add(new Person
            //{
            //    FirstName = "Alireza1",
            //    LastName = "Oroumand1",
            //    Age = 1000
            //});
            //var t = dbContext.People.OrderBy(c => c.FullName);

            //dbContext.BankAccouts.Add(new BankAccout
            //{
            //    Name = "FirstAccount",
            //    Value = 1000
            //});

            //var acc = dbContext.BankAccouts.FirstOrDefault();
            //acc.Value = 100;

            //dbContext.SaveChanges();
            ShowData();
            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }

        private static void ShowData()
        {
          //2000

            Post(1,1000,2000);
        }

        private static void Post(int id, int value,int oldValue)
        {

            var dbContext = new MyDbContext();
            var acc = dbContext.BankAccouts.FirstOrDefault();
            acc.Value = value;
            dbContext.Entry(acc).Property(c => c.Value).OriginalValue = oldValue;
            //Read From Database by id

            //Set Value

            //updatedatabase

        }
    }
}
