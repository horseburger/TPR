using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bookstore.Objects;
using Newtonsoft.Json;

namespace Bookstore
{
    class DataService
    {
        private IDataRepository repository;

        public DataService(IDataRepository repository)
        {
            this.repository = repository;
        }

        public event EventHandler EventAdded
        {
            add => repository.EventAdded += value;
            remove => repository.EventAdded -= value;
        }
        
        public event EventHandler EventRemoved
        {
            add => repository.EventAdded += value;
            remove => repository.EventAdded -= value;
        }
        //Zwróć
        public string Get(List<Client> clients)
        {
            return JsonConvert.SerializeObject(clients);
        }

        public string Get(Dictionary<int, Book> books)
        {
            return JsonConvert.SerializeObject(books);
        }

        public string Get(ObservableCollection<Event> receipts)
        {
            return JsonConvert.SerializeObject(receipts);
        }

        public string Get(List<Status> statuses)
        {
            return JsonConvert.SerializeObject(statuses);
        }

        //Dodaj
        public void AddClient(Client client)
        {
            this.repository.AddClient(client);
        }
        public void AddClient(string name, string surname)
        {
            this.repository.AddClient(new Client(name, surname));
        }
        public void AddBook(Book book)
        {
            this.repository.AddBook(book);
        }
        public void AddBook(int id, string info)
        {
            this.repository.AddBook(new Book(id, info));
        }
        public void AddPurchase(Event purchase)
        {
            this.repository.AddEvent(purchase);
        }
        public void AddPurchase(Client who, Status statusInfo, bool method)
        {

            this.repository.AddEvent(new Purchase(who, statusInfo, DateTime.Now, method));
        }
        public void AddStatus(Status status)
        {
            this.repository.AddStatus(status);
        }
        public void AddStatus(Book product, float price)
        {
            this.repository.AddStatus(new Status(product, price));
        }

        //Wyszukaj
        public List<Client> SearchClient(string pattern)
        {
            List<Client> rezultat = new List<Client>();

            foreach (Client wykaz in this.repository.GetAllClient())
            {
                if (wykaz.ToString().Contains(pattern)) rezultat.Add(wykaz);
            }
            return rezultat;
        }

        public Dictionary<int, Book> SearchBook(string pattern)
        {
            Dictionary<int, Book> rezultat = new Dictionary<int, Book>();

            foreach (var item in this.repository.GetAllBooks())
            {
                if (item.Value.ToString().Contains(pattern)) rezultat.Add(item.Key, item.Value);
            }
            return rezultat;
        }
    
        public ObservableCollection<Event> SearchEvent(DateTime borrowDate)
        {
        
        ObservableCollection<Event> rezultat = new ObservableCollection<Event>();

            foreach (Event zdarzenie in this.repository.GetAllEvents())
            {
                if (zdarzenie.Date > borrowDate) rezultat.Add(zdarzenie);
            }
            return rezultat;
        }
        public List<Status> SearchStatus(float minPrice, double maxPrice)
        {
            List<Status> rezultat = new List<Status>();

            foreach (Status opis in this.repository.GetAllStatus())
            {
                if (opis.Price >= minPrice && opis.Price <= maxPrice) rezultat.Add(opis);
            }
            return rezultat;
        }

        //Znajdź powiązania
        public ObservableCollection<Event> SearchReceiptsByClient(Client client)
        {
            ObservableCollection<Event> receipts = new ObservableCollection<Event>();

            foreach (Event zdarzenie in this.repository.GetAllEvents())
            {
                if (zdarzenie.Who.Equals(client)) receipts.Add(zdarzenie);
            }

            return receipts;
        }

        public ObservableCollection<Event> SearchReceiptsByStatus(Status status)
        {

            ObservableCollection<Event> zdarzenia = new ObservableCollection<Event>();

            foreach (Event zdarzenie in this.repository.GetAllEvents())
            {
                if (zdarzenie.StatusInfo.Equals(status)) zdarzenia.Add(zdarzenie);
            }

            return zdarzenia;
        }
        public ObservableCollection<Event> SearchReceiptsByClientAndStatus(Client client, Status status)
        {
            ObservableCollection<Event> receipts = new ObservableCollection<Event>();

            foreach (Event receipt in this.repository.GetAllEvents())
            {
                if (receipt.StatusInfo.Equals(status) && receipt.Who.Equals(client)) receipts.Add(receipt);
            }
            return receipts;
        }
        public List<Status> SearchStatusesByBooks(Book book)
        {
            List<Status> statuses = new List<Status>();

            foreach (Status status in this.repository.GetAllStatus())
            {
                if (status.Product.Equals(book)) statuses.Add(status);
            }

            return statuses;
        }

        //Usuwanie
        public bool DeleteClient(Client client)
        {
            return this.repository.DeleteClient(client);
        }

        public bool DeleteBook(Book book)
        {
            return this.repository.DeleteBook(book);
        }

        public bool DeleteStatus(Status status)
        {
            return this.repository.DeleteStatus(status);
        }

        public bool DeleteReceipt(Event purchase)
        {
            return this.repository.DeleteEvent(purchase);
        }
        public bool DeleteReceipt(Client client, Status status)
        {
            bool delete = false;

            foreach (Event receipt in SearchReceiptsByClientAndStatus(client, status))
            {
                this.repository.DeleteEvent(receipt);
                delete = true;
            }
            return delete;
        }

    }
}

