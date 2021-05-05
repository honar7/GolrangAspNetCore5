using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Session12.Test.MyLogic.Test
{
    public class BadLogicFixture : IDisposable
    {
        public BadLogic BadLogic { get; set; }
        public BadLogicFixture()
        {
            BadLogic = new BadLogic();
        }
        public void Dispose()
        {
        }
    }

    [CollectionDefinition("BadLogicFixture")]
    public class BadLogicFixtureCollection: ICollectionFixture<BadLogicFixture>
    {

    }


    [Collection("BadLogicFixture")]
    public class BadLogicTest//:IClassFixture<BadLogicFixture>
    {
        BadLogic sut;
        public BadLogicTest(BadLogicFixture badLogicFixture)
        {
            sut = badLogicFixture.BadLogic;
        }
        [Fact]
        public void Test01()
        {
            
            sut.Do();
            Assert.True(true);
        }
        [Fact]
        public void Test02()
        {

            sut.Do();
            Assert.True(true);
        }
        [Fact]
        public void Test03()
        {
            sut.Do();
            Assert.True(true);
        }
    }
}
