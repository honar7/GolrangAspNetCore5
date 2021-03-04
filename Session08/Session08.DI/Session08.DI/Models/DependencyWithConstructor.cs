using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session08.DI.Models
{
    public class DependencyWithConstructor
    {
        private readonly int _age;

        public DependencyWithConstructor(int age)
        {
            _age = age;
        }

        public void WriteAge()
        {
            Console.WriteLine(_age);
        }
    }
}
