using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Session12.Test.MyLogic.Test
{
    public class DDTest
    {
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2,2,4)]
        public void InlineDDTest(int x,int y,int output)
        {
            var mybisuness = new MyBusiness();

            //Act
            var actualResult = mybisuness.AddTowNumber(x, y);
            //Assert
            Assert.Equal(output, actualResult);

        }

        [Theory]
        [MemberData("GetDate", MemberType = typeof(DDTest))]
        public void InlineDDTest2(int x, int y, int output)
        {
            var mybisuness = new MyBusiness();

            //Act
            var actualResult = mybisuness.AddTowNumber(x, y);
            //Assert
            Assert.Equal(output, actualResult);

        }

        [Theory]
        [MyData]
        public void InlineDDTest3(int x, int y, int output)
        {
            var mybisuness = new MyBusiness();

            //Act
            var actualResult = mybisuness.AddTowNumber(x, y);
            //Assert
            Assert.Equal(output, actualResult);

        }

        public static List<object[]> GetDate()
        {
            return new List<object[]>
            {
                new object[]{ 5, 2, 7 },
                new object[]{ 8, 4, 12 }
            };
        }
    }

    public class MyDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return new List<object[]>
            {
                new object[]{ 5, 2, 7 },
                new object[]{ 8, 4, 12 }
            };
        }
    }
}
