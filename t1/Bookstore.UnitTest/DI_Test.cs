using Bookstore.Objects;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class DITest
    {
        [Test]
        public void DataRepositoryDITest()
        {
            IDataRepository repo = new DataRepository(new DataFiller());
            repo.Api.Fill(repo.Storage);
            Assert.AreEqual(10, repo.GetAllBooks().Count);
        }
    }
}