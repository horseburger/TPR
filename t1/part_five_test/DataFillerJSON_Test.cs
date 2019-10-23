using System;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using part_five;
using part_one;
using part_two;

namespace part_five_test
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