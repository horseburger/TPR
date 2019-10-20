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
            DataRepository repo = new DataRepository(new WypelnianieDanymi());
            repo.Api.Fill(repo.GetStorage());
            Assert.AreEqual(10, repo.GetAllKatalog().Count);
        }
    }
}