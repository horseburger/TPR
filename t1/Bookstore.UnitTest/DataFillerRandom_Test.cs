using Bookstore.Objects;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class DataFillerRandom_Test
    {
        [Test]
        public void FillRandom_Test()
        {
            DataRepositoryApi repo = new DataRepository(new DataFillerRandom(10));
            repo.Api.Fill(repo.Storage);
            Assert.AreEqual(10, repo.GetAllKlient().Count);
        }
    }
}