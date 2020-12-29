using CourseStore.Infra.Dal;
using System;

namespace CourseStore.Endpoints.WinUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericRepo.EagerLoading();
            Console.ReadLine();
            Console.WriteLine("Press Any key");
        }
    }
}
