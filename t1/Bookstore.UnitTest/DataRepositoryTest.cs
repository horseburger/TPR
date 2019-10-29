using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bookstore.Objects;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class DataRepositoryTest
    {

        [Test]
        public void AddBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            dataRepository.AddKsiazka(new Book(1, "example"));
            Assert.AreEqual(1, dataRepository.GetAllKsiazka().Count);
        }
        [Test]
        public void GetBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book katalog = new Book(1, "example");
            dataRepository.AddKsiazka(katalog);
            Assert.AreEqual(katalog, dataRepository.GetKsiazka(1));
        }
        [Test]
        public void GetAllBooksTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Dictionary<int, Book> dictionary = dataRepository.GetAllKsiazka();
            Book book = new Book(1, "example");
            dataRepository.AddKsiazka(book);
            Assert.AreEqual(dictionary, dataRepository.GetAllKsiazka());
        }
        [Test]
        public void UpdateBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            dataRepository.AddKsiazka(book);
            Book book2 = new Book(1, "hello");
            dataRepository.UpdateKsiazka(1, book2);
            Assert.AreEqual(book2, dataRepository.GetKsiazka(1));
        }
        [Test]
        public void DeleteBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            dataRepository.AddKsiazka(book);
            dataRepository.DeleteKsiazka(book);
            Assert.AreEqual(0, dataRepository.GetAllKsiazka().Count);
        }
        [Test]
        public void AddClienttTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            dataRepository.AddKlient(new Client("Jan", "Kowalski"));
            Assert.AreEqual(1, dataRepository.GetAllKlient().Count);
        }
        [Test]
        public void GetWykazTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddKlient(client);
            Assert.AreEqual(client, dataRepository.GetKlient(0));
        }
        [Test]
        public void GetAllClientsTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            List<Client> lista = dataRepository.GetAllKlient();
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddKlient(client);
            Assert.AreEqual(lista, dataRepository.GetAllKlient());
        }
        [Test]
        public void UpdateClientTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddKlient(client);
            Client client2 = new Client("Adrian", "Nowak");
            dataRepository.UpdateKlient(0, client2);
            Assert.AreEqual(client2, dataRepository.GetKlient(0));
        }
        [Test]
        public void DeleteClientTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddKlient(client);
            dataRepository.DeleteKlient(client);
            Assert.AreEqual(0, dataRepository.GetAllKlient().Count);
        }
        [Test]
        public void AddReceiptTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            dataRepository.AddZdarzenie(new Receipt(new Client("Jan", "Kowalski"), System.DateTime.Now, new Status(new Book(0, "hello"), 3.99f)));
            Assert.AreEqual(1, dataRepository.GetAllZdarzenie().Count);
        }
        [Test]
        public void GetReceiptTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Receipt receipt = new Receipt(client, System.DateTime.Now, status);
            dataRepository.AddZdarzenie(receipt);
            Assert.AreEqual(receipt, dataRepository.GetZdarzenie(0));
        }
        [Test]
        public void GetAllReceiptsTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            ObservableCollection<Receipt> zdarzenia = dataRepository.GetAllZdarzenie();
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Receipt receipt = new Receipt(client, System.DateTime.Now, status);
            dataRepository.AddZdarzenie(receipt);
            Assert.AreEqual(zdarzenia, dataRepository.GetAllZdarzenie());
        }
        [Test]
        public void UpdateReceiptTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Receipt receipt = new Receipt(client, System.DateTime.Now, status);
            dataRepository.AddZdarzenie(receipt);
            Receipt receipt2 = new Receipt(client, System.DateTime.Now.AddMinutes(5), status);
            dataRepository.UpdateZdarzenie(0, receipt2);
            Assert.AreEqual(receipt2, dataRepository.GetZdarzenie(0));
        }
        [Test]
        public void DeleteReceiptTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Receipt receipt = new Receipt(client, System.DateTime.Now, status);
            dataRepository.AddZdarzenie(receipt);
            dataRepository.DeleteZdarzenie(receipt);
            Assert.AreEqual(0, dataRepository.GetAllZdarzenie().Count);
        }
        [Test]
        public void AddStatusTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            dataRepository.AddOpisStanu(new Status(book, 3.99f));
            Assert.AreEqual(1, dataRepository.GetAllOpisStanu().Count);
        }
        [Test]
        public void GetOpisStanuTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddOpisStanu(status);
            Assert.AreEqual(status, dataRepository.GetOpisStanu(0));
        }
        [Test]
        public void GetAllStatusesTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            List<Status> list = dataRepository.GetAllOpisStanu();
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddOpisStanu(status);
            Assert.AreEqual(list, dataRepository.GetAllOpisStanu());
        }
        [Test]
        public void UpdateStatusTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddOpisStanu(status);
            Status status2 = new Status(book, 8.99f);
            dataRepository.UpdateOpisStanu(0, status2);
            Assert.AreEqual(status2, dataRepository.GetOpisStanu(0));
        }
        [Test]
        public void DeleteStatusTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddOpisStanu(status);
            dataRepository.DeleteOpisStanu(status);
            Assert.AreEqual(0, dataRepository.GetAllOpisStanu().Count);
        }

        [Test]
        public void ReceiptAddedTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            bool flag = false;
            dataRepository.ReceiptAdded += (object s, EventArgs e) =>
            {
                flag = true;
            };
            dataRepository.AddZdarzenie(new Receipt(client, DateTime.Now, status));
            Assert.AreEqual(true, flag);
        }

        [Test]
        public void ReceiptRemovedTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Receipt receipt = new Receipt(client, DateTime.Now, status);
            dataRepository.AddZdarzenie(receipt);
            bool flag = false;
            dataRepository.ReceiptRemoved += (object s, EventArgs e) =>
            {
                flag = true;
            };
            dataRepository.DeleteZdarzenie(receipt);
            Assert.AreEqual(true, flag);
        }
    }
}