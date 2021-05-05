using System;

namespace Session12.Test.MyLogic
{
    public class BadLogic
    {
        public BadLogic()
        {
            System.Threading.Thread.Sleep(4000);
        }

        public void Do()
        {

        }
    }

    public class Price
    {
        private int _price;
        public int GetPrice()
        {
            return _price;
        }
        public void SetPrice(int value)
        {
            if (value < 0)
                throw new Exception("Invalid Value");

            _price = value;
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Student:Person
    {
        public string StNumber { get; set; }
    }

    public class Teacher : Person
    {
        public string TeNumber { get; set; }
    }

    public enum PersonType
    {
        Teacher,
        Student
    }
    public class Factory
    {
        public static Person GetPerson(PersonType personType)
        {
            if (personType == PersonType.Student)
                return new Student();
            return new Teacher();
        }
    }
    public class MyBusiness
    {

        public int AddTowNumber(int input01,int input02)
        {
            return input01 + input02;
        }

        public bool IsGraterThan(int input1,int input2)
        {
            return input1 > input2;
        }

        public string ConcateName(string firstName,string LastName)
        {
            return $"{firstName} {LastName}";
        }
    }
}
