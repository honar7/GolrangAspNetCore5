using HelloEF.DAL;
using System;

namespace HelloEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataClass.AddCourse("Domain Driven Design");
            //DataClass.AddTeacher(1, "Alireza", "Oroumand");
            //DataClass.Edit(2, "Microservice");

            DataClass.ReadAllCourse();

            Console.WriteLine("Hello World!");
        }
    }
}
