using System;
using System.IO;
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
            DataRepository repo = new DataRepository(new WypelnianieDanymi());
            repo.Api.Fill(repo.Storage);
            var stream1 = new MemoryStream();
            var ser = new 
        }
    }
}