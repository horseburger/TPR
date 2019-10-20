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
            DataRepository tmp = new DataRepository(new WypelnianieDanymi());
            tmp.Api.Fill(tmp.GetStorage());
            string json = JsonConvert.SerializeObject(tmp.GetStorage());
            File.WriteAllText("./inputDataFiller.json", json);
            DataRepository repo = new DataRepository(new DataFillerJSON("./inputDataFiller.json"));
            repo.Api.Fill(repo.GetStorage());
            Assert.AreEqual(10, repo.GetAllWykaz().Count);
        }
    }
}