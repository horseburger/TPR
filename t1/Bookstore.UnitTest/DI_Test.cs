using Bookstore.Objects;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class DI_Test
    {
        [Test]
        public void DataRepositoryDITest()
        {
            DataRepositoryApi repo = new DataRepository(new WypelnianieDanymi());
            repo.Api.Fill(repo.Storage);
            Assert.AreEqual(10, repo.GetAllKsiazka().Count);
        }
    }
}