using System;
using System.IO;
using Bookstore;
using NUnit.Framework;

namespace CustomSerializer.UnitTest
{
    public class OwnSerializationTest
    {
        private DataContext data;
        private DataRepository repo;
        private Serializer serializer;
        const string filename = "OwnTest.json";

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
        public void SerializeAndDeserializeOwn()
        {
            //Serialize
            serializer.Serialize(filename, data);
            FileInfo info = new FileInfo(filename);
            Assert.IsTrue(info.Exists);
            Assert.IsTrue(info.Length >= 100, $"File length: {info.Length}");

            //Deserialize
            DataContext dataFromOwnSerializer = serializer.Deserialize(filename);
            for(int i = 0; i < data.Events.Count; i++)
            {
                Console.WriteLine(i + ": " + data.Events[i] + " : " + dataFromOwnSerializer.Events[i]);
            }
            Assert.IsTrue(dataFromOwnSerializer.Equals(data));


        }
    }
}
