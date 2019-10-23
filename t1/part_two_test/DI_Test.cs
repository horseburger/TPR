using NUnit.Framework;
using part_one;
using part_two;

namespace part_two_test
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