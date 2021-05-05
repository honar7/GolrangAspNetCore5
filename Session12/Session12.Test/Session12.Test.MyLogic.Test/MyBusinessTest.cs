using System;
using Xunit;
using Xunit.Abstractions;

namespace Session12.Test.MyLogic.Test
{
    public class MyBusinessTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public MyBusinessTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Create New Instance");
        }
        [Fact]
        [Trait("Category","t01")]
        public void Test1()
        {
            //Arrange
            var mybisuness = new MyBusiness();

            var input1 = 2;
            var input2 = 4;

            var expectedResult = 6;
            //Act
            var actualResult = mybisuness.AddTowNumber(input1, input2);
            //Assert
            Assert.Equal(expectedResult, actualResult);

            //Assert.NotEqual
            //Assert.InRange
            //Assert.NotInRange

        }

        [Fact]
        [Trait("Category", "t01")]
        public void IsGraterThan()
        {
            //Arrange
            var mybisuness = new MyBusiness();

            var input1 = 4;
            var input2 = 2;

            //Act
            var actualResult = mybisuness.IsGraterThan(input1, input2);
            //Assert
            Assert.True(actualResult);
            //Assert.False
        }


        [Fact]
        [Trait("Category", "t02")]
        public void Cocate()
        {
            //Arrange
            var mybisuness = new MyBusiness();

            var input1 = "Alireza";
            var input2 = "Oroumand";
            var expected = "Alireza Oroumand";
            //Act
            var actualResult = mybisuness.ConcateName(input1, input2);
            //Assert
            Assert.Equal(expected, actualResult);
            //Assert.Equal
            //Assert.StartsWith
            //Assert.EndsWith
            //Assert.Contains()
            //Assert.Matches

        }
        [Fact]
        [Trait("Category", "t03")]
        public void GetPerson()
        {
            _testOutputHelper.WriteLine("Readt For Get Person Test");
            var studnet = Factory.GetPerson(PersonType.Student);
            
            Assert.IsAssignableFrom<Person>(studnet);
            //Assert.Null
            //Assert.NotNull
            //Assert.IsType
            //Assert.IsNotType
            //Assert.IsAssignableFrom
            //Assert.Same()
            //Assert.NotSame

        }
        [Fact(Skip ="Modiremoon Gofte Avaz Beshe")]
        [Trait("Category", "t03")]
        public void CheckPrice()
        {
            var price = new Price();
            
            Assert.Throws<Exception>(() => price.SetPrice(0));
        }


    }
}
