using System.IO;
using Bookstore.Objects;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class DataFillerTextFile_Test
    {
        [Test]
        public void FillJSON_Test()
        {
            DataRepositoryApi tmp = new DataRepository(new WypelnianieDanymi());
            tmp.Api.Fill(tmp.Storage);
            string json = JsonConvert.SerializeObject(tmp.Storage);
            File.WriteAllText("./inputDataFiller.json", json);
            DataRepositoryApi repo = new DataRepository(new DataFillerJSON("./inputDataFiller.json"));
            repo.Api.Fill(repo.Storage);
            Assert.AreEqual(10, repo.GetAllKlient().Count);
        }
    }
}