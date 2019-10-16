using NUnit.Framework;
using part_five;
using part_one;

namespace part_five_test
{
    [TestFixture]
    public class DataFillerRandom_Test
    {
        [Test]
        public void FillRandom_Test()
        {
            DataRepository repo = new DataRepository(new DataFillerRandom(10));
            repo.Api.Fill(repo.storage);
            Assert.AreEqual(10, repo.storage.wykazList.Count);
        }
    }
}