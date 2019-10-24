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

            this.Storage.Receipts.CollectionChanged += ZdarzenieChanged;
        }

        private void ZdarzenieChanged(object sender, NotifyCollectionChangedEventArgs e)
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
        public void AddKsiazka(Book pozycja)
        {
            try
            {
                Storage.Books.Add(pozycja.Id, pozycja);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Book GetKsiazka(int id)
        {
            Book katalog = null;
            try
            {
                 katalog = Storage.Books[id];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return katalog;
        }
        public Dictionary<int, Book> GetAllKsiazka()
        {
            return Storage.Books;
        }
        public void UpdateKsiazka(int id, Book pozycja)
        {
            try
            {
                Storage.Books[id] = pozycja;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteKsiazka(Book pozycja)
        {
           return Storage.Books.Remove(pozycja.Id);
        }
        public void AddKlient(Client element)
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
        public Client GetKlient(int id)
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
        public List<Client> GetAllKlient()
        {
            return Storage.Clients;
        }
        public void UpdateKlient(int id, Client element)
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
        public bool DeleteKlient(Client element)
        {
                return Storage.Clients.Remove(element);
        }
        public void AddZdarzenie(Receipt receipt)
        {
            try
            {
                Storage.Receipts.Add(receipt);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Receipt GetZdarzenie(int id)
        {
          try
            {
                return Storage.Receipts[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public ObservableCollection<Receipt> GetAllZdarzenie()
        {
            return Storage.Receipts;
        }
        public void UpdateZdarzenie(int id, Receipt element)
        {
            try
            {
                Storage.Receipts[id] = element;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteZdarzenie(Receipt element)
        {
            return Storage.Receipts.Remove(element);
        }
        public void AddOpisStanu(Status opis)
        {
            try
            {
                Storage.Statuses.Add(opis);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Status GetOpisStanu(int id)
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
        public List<Status> GetAllOpisStanu()
        {
            return Storage.Statuses;
        }
        public void UpdateOpisStanu(int id, Status stan)
        {
            try
            {
                Storage.Statuses[id] = stan;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteOpisStanu(Status element)
        {
            return Storage.Statuses.Remove(element);
        }
    }
}