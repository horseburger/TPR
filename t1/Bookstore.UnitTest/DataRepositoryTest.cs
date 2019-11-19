using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bookstore.Entities;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class DataRepositoryTest
    {

        [Test]
        public void AddBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            dataRepository.AddBook(new Book(1, "example"));
            Assert.AreEqual(1, dataRepository.GetAllBooks().Count);
        }
        [Test]
        public void GetBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Book katalog = new Book(1, "example");
            dataRepository.AddBook(katalog);
            Assert.AreEqual(katalog, dataRepository.GetBook(1));
        }
        [Test]
        public void GetAllBooksTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Dictionary<int, Book> dictionary = dataRepository.GetAllBooks();
            Book book = new Book(1, "example");
            dataRepository.AddBook(book);
            Assert.AreEqual(dictionary, dataRepository.GetAllBooks());
        }
        [Test]
        public void UpdateBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Book book = new Book(1, "example");
            dataRepository.AddBook(book);
            Book book2 = new Book(1, "hello");
            dataRepository.UpdateBook(1, book2);
            Assert.AreEqual(book2, dataRepository.GetBook(1));
        }
        [Test]
        public void DeleteBookTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Book book = new Book(1, "example");
            dataRepository.AddBook(book);
            dataRepository.DeleteBook(book);
            Assert.AreEqual(0, dataRepository.GetAllBooks().Count);
        }
        [Test]
        public void AddClienttTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            dataRepository.AddClient(new Client("Jan", "Kowalski"));
            Assert.AreEqual(1, dataRepository.GetAllClient().Count);
        }
        [Test]
        public void GetClientTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddClient(client);
            Assert.AreEqual(client, dataRepository.GetClient(0));
        }
        [Test]
        public void GetAllClientsTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            List<Client> lista = dataRepository.GetAllClient();
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddClient(client);
            Assert.AreEqual(lista, dataRepository.GetAllClient());
        }
        [Test]
        public void UpdateClientTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddClient(client);
            Client client2 = new Client("Adrian", "Nowak");
            dataRepository.UpdateClient(0, client2);
            Assert.AreEqual(client2, dataRepository.GetClient(0));
        }
        [Test]
        public void DeleteClientTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            dataRepository.AddClient(client);
            dataRepository.DeleteClient(client);
            Assert.AreEqual(0, dataRepository.GetAllClient().Count);
        }
        [Test]
        public void AddEventTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Book book = new Book(0, "stary człowiek a może");
            Client client = new Client("Jan", "Kowalski");
            Status status = new Status(book, 39.99f);
            dataRepository.AddEvent(new Purchase(client, status, DateTime.Now, false));
            Assert.AreEqual(1, dataRepository.GetAllEvents().Count);
        }
        [Test]
        public void GetEventTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Event borrow = new Borrow(client, status, DateTime.Now, DateTime.Now.AddMonths(1));
            dataRepository.AddEvent(borrow);
            Assert.AreEqual(borrow, dataRepository.GetEvent(0));
        }
        [Test]
        public void GetAllEventsTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            ObservableCollection<Event> zdarzenia = dataRepository.GetAllEvents();
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Event purchase = new Purchase(client, status, DateTime.Now, false);
            dataRepository.AddEvent(purchase);
            Assert.AreEqual(zdarzenia, dataRepository.GetAllEvents());
        }
        [Test]
        public void UpdateEventTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Event purchase = new Purchase(client, status, DateTime.Now, true);
            dataRepository.AddEvent(purchase);
            status = new Status(book, 19.99f);
            Event purchase2 = new Purchase(client, status, DateTime.Now, false);
            dataRepository.UpdateEvent(0, purchase2);
            Assert.AreEqual(purchase2, dataRepository.GetEvent(0));
        }
        [Test]
        public void DeleteEventTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Event purchase = new Purchase(client, status, DateTime.Now, false);
            dataRepository.AddEvent(purchase);
            dataRepository.DeleteEvent(purchase);
            Assert.AreEqual(0, dataRepository.GetAllEvents().Count);
        }
        [Test]
        public void AddStatusTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Book book = new Book(1, "example");
            dataRepository.AddStatus(new Status(book, 3.99f));
            Assert.AreEqual(1, dataRepository.GetAllStatus().Count);
        }
        [Test]
        public void GetOpisStanuTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddStatus(status);
            Assert.AreEqual(status, dataRepository.GetStatus(0));
        }
        [Test]
        public void GetAllStatusesTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            List<Status> list = dataRepository.GetAllStatus();
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddStatus(status);
            Assert.AreEqual(list, dataRepository.GetAllStatus());
        }
        [Test]
        public void UpdateStatusTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
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
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            dataRepository.AddStatus(status);
            dataRepository.DeleteStatus(status);
            Assert.AreEqual(0, dataRepository.GetAllStatus().Count);
        }

        [Test]
        public void EventAddedTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            bool flag = false;
            dataRepository.EventAdded += (s, e) =>
            {
                flag = true;
            };
            dataRepository.AddEvent(new Purchase(client, status, DateTime.Now, false));
            Assert.AreEqual(true, flag);
        }

        [Test]
        public void EventRemovedTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(1, "example");
            Status status = new Status(book, 9.99f);
            Event purchase = new Purchase(client, status, DateTime.Now, true);
            dataRepository.AddEvent(purchase);
            bool flag = false;
            dataRepository.EventRemoved += (s, e) =>
            {
                flag = true;
            };
            dataRepository.DeleteEvent(purchase);
            Assert.AreEqual(true, flag);
        }

        [Test]
        public void AddBorrowTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(0, "example");
            Status status = new Status(book, 39.99f);
            Event borrow = new Borrow(client, status, DateTime.Now, DateTime.Today.AddDays(1));
            dataRepository.AddEvent(borrow);
            Assert.IsTrue(dataRepository.GetEvent(0).GetType() == typeof(Borrow));
        }

        [Test]
        public void PolymorphismTest()
        {
            IDataRepository dataRepository = new DataRepository(new DataFillerConstants());
            Client client = new Client("Jan", "Kowalski");
            Book book = new Book(0, "example");
            Status status = new Status(book, 39.99f);
            Event purchase = new Purchase(client, status, DateTime.Now, true);
            Event borrow = new Borrow(client, status, DateTime.Now, DateTime.Now.AddDays(1));
            dataRepository.AddEvent(purchase);
            dataRepository.AddEvent(borrow);
            Assert.IsTrue(dataRepository.GetEvent(0).GetType() == typeof(Purchase));
            Assert.IsTrue(dataRepository.GetEvent(1).GetType() == typeof(Borrow));
        }
    }
    
}