using NUnit.Framework;
using Bookstore;
using Bookstore.Objects;
using System;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Diagnostics;

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
            data = new DataContext();
            repo = new DataRepository(new Filler());
            repo.Api.Fill(data);
            if (!File.Exists(filename))
            {
                File.Create(filename).Dispose();
            }
        }

        [Test]
        public void SerializeToJSON()
        {
            serializer.SerializeItemJson(filename, data);
            FileInfo info = new FileInfo(filename);
            Assert.IsTrue(info.Exists);
            string fileContent = File.ReadAllText(filename, Encoding.UTF8);
            Debug.Write(fileContent);

        }
        [Test]
        public void DeserializeToJSON()
        {
            SerializeToJSON();
            DataContext dataFromJson = serializer.DeserializeItemJsonFromFile(filename);
            Assert.IsTrue(dataFromJson.Equals(data));

        }
    }
    public class Filler : IDataFiller
    {
        public void Fill(DataContext context)
        {
            Book book = new Book(0, "this is a book");
            Status status = new Status(book, 39.99f);
            Client client = new Client("Kamil", "Glik");
            Client client2 = new Client("Ireneusz", "Jeleń");
            Event purchase = new Purchase(client, status, DateTime.Now, false);
            Event borrow = new Borrow(client2, status, DateTime.Now, DateTime.Now.AddMonths(1));
            book.Events.Add(purchase);
            book.Events.Add(borrow);
            for (int i = 0; i < 10; i++)
            {
                context.Books.Add(i, book);
                context.Clients.Add(client);
                context.Events.Add(purchase);
                context.Statuses.Add(status);
            }
        }
    }
}

