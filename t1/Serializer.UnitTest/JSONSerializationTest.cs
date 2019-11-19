using NUnit.Framework;
using Bookstore;
using Bookstore.Entities;
using System;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace Serializer.UnitTest
{
    public class JSONSerializationTest
    {
        private DataContext data;
        private DataRepository repo;
        private Serializer serializer;
        const string filename = "JSONTest.json";

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
        public void SerializeAndDeserializeJSON()
        {
            //Serialize
            serializer.SerializeItemJson(filename, data);
            FileInfo info = new FileInfo(filename);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 100, $"File length: {info.Length}");

            //Deserialize
            DataContext dataFromJson = serializer.DeserializeItemJsonFromFile(filename);
            Assert.IsTrue(dataFromJson.Equals(data));
        }
    }
    
}

