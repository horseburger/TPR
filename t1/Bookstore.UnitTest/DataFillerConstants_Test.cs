using Bookstore.Entities;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class DataFillerConstants_Test
    {
        [Test]
        public void FillConstant_Test()
        {
            IDataRepository repo = new DataRepository(new DataFillerConstants());
            repo.Api.Fill(repo.Storage);
            Assert.AreEqual(10, repo.GetAllBooks().Count);
        }
    }
}