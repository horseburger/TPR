using NUnit.Framework;
using Bookstore;

namespace Serializer.UnitTest
{
    public class JSONSerializationTest
    {
        DataContext data;

        [SetUp]
        public void Setup()
        {
            data = new DataContext();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}

