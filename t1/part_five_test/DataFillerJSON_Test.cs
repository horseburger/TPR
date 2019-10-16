using System;
using Newtonsoft.Json;
using NUnit.Framework;
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
            DataRepository repo = new DataRepository(new WypelnianieDanymi());
            repo.Api.Fill(repo.Storage);
            string json = JsonConvert.SerializeObject(repo.Storage, Formatting.Indented);
            System.IO.File.WriteAllText("inputDataFiller.json", json);
        }
    }
}