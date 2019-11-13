using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Bookstore.Objects;

namespace Bookstore
{
    public class DataRepository : IDataRepository
    {
        public DataContext Storage { get; set; }
        public IDataFiller Api { get; set; }

        public event EventHandler ReceiptAdded;
        public event EventHandler ReceiptRemoved;

        public DataRepository(IDataFiller api)
        {
            this.Storage = new DataContext();
            this.Api = api;

            this.Storage.Events.CollectionChanged += ReceiptChanged;
        }

        private void ReceiptChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ReceiptAdded?.Invoke(this, new EventArgs());
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                ReceiptRemoved?.Invoke(this, new EventArgs());
            }
        }
        
        public DataContext GetStorage()
        {
            return Storage;
        }
        public void AddBook(Book book)
        {
            try
            {
                Storage.Books.Add(book.Id, book);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Book GetBook(int id)
        {
            Book book = null;
            try
            {
                 book = Storage.Books[id];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return book;
        }
        public Dictionary<int, Book> GetAllBooks()
        {
            return Storage.Books;
        }
        public void UpdateBook(int id, Book book)
        {
            try
            {
                Storage.Books[id] = book;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteBook(Book book)
        {
           return Storage.Books.Remove(book.Id);
        }
        public void AddClient(Client element)
        {
            try
            {
                Storage.Clients.Add(element);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Client GetClient(int id)
        {
            try
            {
                return Storage.Clients[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
        public List<Client> GetAllClient()
        {
            return Storage.Clients;
        }
        public void UpdateClient(int id, Client element)
        {
            try
            {
                Storage.Clients[id] = element;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteClient(Client element)
        {
                return Storage.Clients.Remove(element);
        }
        public void AddPurchase(Event purchase)
        {
            try
            {
                Storage.Events.Add(purchase);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Event GetReceipt(int id)
        {
          try
            {
                return Storage.Events[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public ObservableCollection<Event> GetAllReceipts()
        {
            return Storage.Events;
        }
        public void UpdateReceipt(int id, Event element)
        {
            try
            {
                Storage.Events[id] = element;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DelteReceipt(Event element)
        {
            return Storage.Events.Remove(element);
        }
        public void AddStatus(Status status)
        {
            try
            {
                Storage.Statuses.Add(status);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Status GetStatus(int id)
        {
            try
            {
                return Storage.Statuses[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public List<Status> GetAllStatus()
        {
            return Storage.Statuses;
        }
        public void UpdateStatus(int id, Status status)
        {
            try
            {
                Storage.Statuses[id] = status;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteStatus(Status element)
        {
            return Storage.Statuses.Remove(element);
        }
    }
}