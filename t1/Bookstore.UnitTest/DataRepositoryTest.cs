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
            dataRepository.AddBook(new Book(1, "example"));
            Assert.AreEqual(1, dataRepository.GetAllBooks().Count);
        }
        [Test]
        public void GetBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book katalog = new Book(1, "example");
            dataRepository.AddBook(katalog);
            Assert.AreEqual(katalog, dataRepository.GetBook(1));
        }
        [Test]
        public void GetAllBooksTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Dictionary<int, Book> dictionary = dataRepository.GetAllBooks();
            Book book = new Book(1, "example");
            dataRepository.AddBook(book);
            Assert.AreEqual(dictionary, dataRepository.GetAllBooks());
        }
        [Test]
        public void UpdateBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            dataRepository.AddBook(book);
            Book book2 = new Book(1, "hello");
            dataRepository.UpdateBook(1, book2);
            Assert.AreEqual(book2, dataRepository.GetBook(1));
        }
        [Test]
        public void DeleteBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            dataRepository.AddBook(book);
            dataRepository.DeleteBook(book);
            Assert.AreEqual(0, dataRepository.GetAllBooks().Count);
        }
        [Test]
        public void AddClienttTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            dataRepository.AddClient(new Client("Jan", "Kowalski"));
            Assert.AreEqual(1, dataRepository.GetAllClient().Count);
        }
        [Test]
        public void GetWykazTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddClient(client);
            Assert.AreEqual(client, dataRepository.GetClient(0));
        }
        [Test]
        public void GetAllClientsTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            List<Client> lista = dataRepository.GetAllClient();
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddClient(client);
            Assert.AreEqual(lista, dataRepository.GetAllClient());
        }
        [Test]
        public void UpdateClientTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddClient(client);
            Client client2 = new Client("Adrian", "Nowak");
            dataRepository.UpdateClient(0, client2);
            Assert.AreEqual(client2, dataRepository.GetClient(0));
        }
        [Test]
        public void DeleteClientTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddClient(client);
            dataRepository.DeleteClient(client);
            Assert.AreEqual(0, dataRepository.GetAllClient().Count);
        }
        [Test]
        public void AddPurchaseTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            dataRepository.AddPurchase(new Purchase(new Client("Jan", "Kowalski"), new Status(new Book(0, "hello"), 3.99f)));
            Assert.AreEqual(1, dataRepository.GetAllReceipts().Count);
        }
        [Test]
        public void GetPurchaseTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Purchase purchase = new Purchase(client, status);
            dataRepository.AddPurchase(purchase);
            Assert.AreEqual(purchase, dataRepository.GetReceipt(0));
        }
        [Test]
        public void GetAllPurchaseTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            ObservableCollection<Purchase> zdarzenia = dataRepository.GetAllReceipts();
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Purchase purchase = new Purchase(client, status);
            dataRepository.AddPurchase(purchase);
            Assert.AreEqual(zdarzenia, dataRepository.GetAllReceipts());
        }
        [Test]
        public void UpdatePurchaseTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Purchase purchase = new Purchase(client, status);
            dataRepository.AddPurchase(purchase);
            status = new Status(book, 19.99f);
            Purchase receipt2 = new Purchase(client, status);
            dataRepository.UpdateReceipt(0, receipt2);
            Assert.AreEqual(receipt2, dataRepository.GetReceipt(0));
        }
        [Test]
        public void DeletePurchaseTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Purchase purchase = new Purchase(client, status);
            dataRepository.AddPurchase(purchase);
            dataRepository.DelteReceipt(purchase);
            Assert.AreEqual(0, dataRepository.GetAllReceipts().Count);
        }
        [Test]
        public void AddStatusTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            dataRepository.AddStatus(new Status(book, 3.99f));
            Assert.AreEqual(1, dataRepository.GetAllStatus().Count);
        }
        [Test]
        public void GetOpisStanuTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddStatus(status);
            Assert.AreEqual(status, dataRepository.GetStatus(0));
        }
        [Test]
        public void GetAllStatusesTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            List<Status> list = dataRepository.GetAllStatus();
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddStatus(status);
            Assert.AreEqual(list, dataRepository.GetAllStatus());
        }
        [Test]
        public void UpdateStatusTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddStatus(status);
            Status status2 = new Status(book, 8.99f);
            dataRepository.UpdateStatus(0, status2);
            Assert.AreEqual(status2, dataRepository.GetStatus(0));
        }
        [Test]
        public void DeleteStatusTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddStatus(status);
            dataRepository.DeleteStatus(status);
            Assert.AreEqual(0, dataRepository.GetAllStatus().Count);
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
            dataRepository.AddPurchase(new Purchase(client, status));
            Assert.AreEqual(true, flag);
        }

        [Test]
        public void ReceiptRemovedTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFiller());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Purchase purchase = new Purchase(client, status);
            dataRepository.AddPurchase(purchase);
            bool flag = false;
            dataRepository.ReceiptRemoved += (object s, EventArgs e) =>
            {
                flag = true;
            };
            dataRepository.DelteReceipt(purchase);
            Assert.AreEqual(true, flag);
        }
    }
}