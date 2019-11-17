using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bookstore;
using Bookstore.Objects;
using NUnit.Framework;

namespace Serializer.UnitTest
{
    public class BinarySerializationTest
    {
        private DataContext data;
        private DataRepository repo;
        private Serializer serializer;
        const string filename = "BinaryTest.json";

        [SetUp]
        public void Setup()
        {
            serializer = new Serializer();
            data = new DataContext();
            repo = new DataRepository(new FillerForTest());
            repo.Api.Fill(data);
            if (!File.Exists(filename))
            {
                File.Create(filename).Dispose();
            }
        }

        [Test]
        public void SerializeAndDeserializeBinary()
        {
            //Serialize
            serializer.SerializeItemBinary(filename, data);
            FileInfo info = new FileInfo(filename);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 100, $"File length: {info.Length}");

            //Deserialize
            DataContext dataFromBinary = serializer.DeserializeItemBinary(filename);
            Assert.IsTrue(dataFromBinary.Equals(data));

        }
    }
}
