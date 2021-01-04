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

            //TipsAndTricks.NormalRelationshipFixup();
            //TipsAndTricks.AddEmp();
            // TipsAndTricks.LoadEmp();
            //TipsAndTricks.AddRootObject();
            TipsAndTricks.LoadRootObject(3);
            Console.WriteLine("Press Any key");

            Console.ReadLine();
        }

        
    }
}
