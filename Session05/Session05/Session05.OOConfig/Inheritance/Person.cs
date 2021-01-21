using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session05.OOConfig.Inheritance
{
    //public enum PersonType
    //{
    //    Student,
    //    Teacher,
    //}
    public abstract  class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public PersonType PersonType { get; set; }
    }
    public class Student:Person
    {
        public string StudentNumber { get; set; }

    }
    public class Teacher : Person
    {
        public string TeacherNumber { get; set; }

    }

}
