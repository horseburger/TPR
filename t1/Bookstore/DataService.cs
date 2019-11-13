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

        public string Get(ObservableCollection<Event> events)
        {
            return JsonConvert.SerializeObject(events);
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
        public void AddEvent(Event evt)
        {
            this.repository.AddEvent(evt);
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
        public ObservableCollection<Event> SearchEventsByClient(Client client)
        {
            ObservableCollection<Event> events = new ObservableCollection<Event>();

            foreach (Event zdarzenie in this.repository.GetAllEvents())
            {
                if (zdarzenie.Who.Equals(client)) events.Add(zdarzenie);
            }

            return events;
        }

        public ObservableCollection<Event> SearchEventsByStatus(Status status)
        {

            ObservableCollection<Event> zdarzenia = new ObservableCollection<Event>();

            foreach (Event zdarzenie in this.repository.GetAllEvents())
            {
                if (zdarzenie.StatusInfo.Equals(status)) zdarzenia.Add(zdarzenie);
            }

            return zdarzenia;
        }
        public ObservableCollection<Event> SearchEventsByClientAndStatus(Client client, Status status)
        {
            ObservableCollection<Event> events = new ObservableCollection<Event>();

            foreach (Event evt in this.repository.GetAllEvents())
            {
                if (evt.StatusInfo.Equals(status) && evt.Who.Equals(client)) events.Add(evt);
            }
            return events;
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

        public bool DeleteEvent(Event evt)
        {
            return this.repository.DeleteEvent(evt);
        }
        public bool DeleteEvent(Client client, Status status)
        {
            bool delete = false;

            foreach (Event evt in SearchEventsByClientAndStatus(client, status))
            {
                this.repository.DeleteEvent(evt);
                delete = true;
            }
            return delete;
        }

    }
}

