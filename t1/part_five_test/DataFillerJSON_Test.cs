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
        public void Test1()
        {
            DataRepository tmp = new DataRepository(new WypelnianieDanymi());
            tmp.Api.Fill(tmp.storage);
            string json = JsonConvert.SerializeObject(tmp.storage);
            File.WriteAllText("./inputDataFiller.json", json);
            DataRepository repo = new DataRepository(new DataFillerJSON("./inputDataFiller.json"));
            repo.Api.Fill(repo.storage);
            Assert.AreEqual(10, repo.storage.wykazList.Count);
        }
    }
}