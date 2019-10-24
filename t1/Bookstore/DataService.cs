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

        public event EventHandler ZdarzenieAdded
        {
            add => repository.ReceiptAdded += value;
            remove => repository.ReceiptAdded -= value;
        }
        
        public event EventHandler ZdarzenieRemoved
        {
            add => repository.ReceiptRemoved += value;
            remove => repository.ReceiptRemoved -= value;
        }
        //Zwróć
        public string Zwroc(List<Client> wykazy)
        {
            return JsonConvert.SerializeObject(wykazy);
        }

        public string Zwroc(Dictionary<int, Book> katalogi)
        {
            return JsonConvert.SerializeObject(katalogi);
        }

        public string Zwroc(ObservableCollection<Receipt> zdarzenia)
        {
            return JsonConvert.SerializeObject(zdarzenia);
        }

        public string Zwroc(List<Status> opisy)
        {
            return JsonConvert.SerializeObject(opisy);
        }

        //Dodaj
        public void DodajWykaz(Client wykaz)
        {
            this.repository.AddKlient(wykaz);
        }
        public void DodajWykaz(string name, string surname)
        {
            this.repository.AddKlient(new Client(name, surname));
        }
        public void DodajKatalog(Book katalog)
        {
            this.repository.AddKsiazka(katalog);
        }
        public void DodajKatalog(int id, string info)
        {
            this.repository.AddKsiazka(new Book(id, info));
        }
        public void DodajZdarzenie(Receipt receipt)
        {
            this.repository.AddZdarzenie(receipt);
        }
        public void DodajZdarzenie(Client who, DateTime borrowdate, Status statusInfo)
        {
            this.repository.AddZdarzenie(new Receipt(who, borrowdate, statusInfo));
        }
        public void DodajOpisStanu(Status opis)
        {
            this.repository.AddOpisStanu(opis);
        }
        public void DodajOpisStanu(Book product, DateTime data_zakupu, float price)
        {
            this.repository.AddOpisStanu(new Status(product, price));
        }

        //Wyszukaj
        public List<Client> SzukajWykaz(string fraza)
        {
            List<Client> rezultat = new List<Client>();

            foreach (Client wykaz in this.repository.GetAllKlient())
            {
                if (wykaz.ToString().Contains(fraza)) rezultat.Add(wykaz);
            }
            return rezultat;
        }

        public Dictionary<int, Book> SzukajKatalog(string fraza)
        {
            Dictionary<int, Book> rezultat = new Dictionary<int, Book>();

            foreach (var item in this.repository.GetAllKsiazka())
            {
                if (item.Value.ToString().Contains(fraza)) rezultat.Add(item.Key, item.Value);
            }
            return rezultat;
        }
        public ObservableCollection<Receipt> SzukajZdarzenia(DateTime borrowDate, DateTime returnDate)
        {
            ObservableCollection<Receipt> rezultat = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.BorrowDate > borrowDate && zdarzenie.ReturnDate < returnDate) rezultat.Add(zdarzenie);
            }
            return rezultat;
        }
        public ObservableCollection<Receipt> SzukajZdarzenia(DateTime borrowDate)
        {
            ObservableCollection<Receipt> rezultat = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.BorrowDate > borrowDate) rezultat.Add(zdarzenie);
            }
            return rezultat;
        }
        public List<Status> SzukajOpisStanu(float minPrice, double maxPrice)
        {
            List<Status> rezultat = new List<Status>();

            foreach (Status opis in this.repository.GetAllOpisStanu())
            {
                if (opis.Price >= minPrice && opis.Price <= maxPrice) rezultat.Add(opis);
            }
            return rezultat;
        }

        //Znajdź powiązania
        public ObservableCollection<Receipt> ZdarzenieAndWykaz(Client wykaz)
        {
            ObservableCollection<Receipt> zdarzenia = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.Who.Equals(wykaz)) zdarzenia.Add(zdarzenie);
            }

            return zdarzenia;
        }

        public ObservableCollection<Receipt> ZdarzeniaAndOpisStanu(Status stan)
        {

            ObservableCollection<Receipt> zdarzenia = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.StatusInfo.Equals(stan)) zdarzenia.Add(zdarzenie);
            }

            return zdarzenia;
        }
        public ObservableCollection<Receipt> WykazAndZdarzenieAndOpisStanu(Client wykaz, Status stan)
        {
            ObservableCollection<Receipt> zdarzenia = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.StatusInfo.Equals(stan) && zdarzenie.Who.Equals(wykaz)) zdarzenia.Add(zdarzenie);
            }
            return zdarzenia;
        }
        public List<Status> OpisStanuAndKatalog(Book katalog)
        {
            List<Status> stany = new List<Status>();

            foreach (Status stan in this.repository.GetAllOpisStanu())
            {
                if (stan.Product.Equals(katalog)) stany.Add(stan);
            }

            return stany;
        }

        //Usuwanie
        public bool UsunWykaz(Client wykaz)
        {
            return this.repository.DeleteKlient(wykaz);
        }

        public bool UsunKatalog(Book katalog)
        {
            return this.repository.DeleteKsiazka(katalog);
        }

        public bool UsunOpisStanu(Status stan)
        {
            return this.repository.DeleteOpisStanu(stan);
        }

        public bool UsunZdarzenie(Receipt receipt)
        {
            return this.repository.DeleteZdarzenie(receipt);
        }
        public bool UsunZdarzenie(Client wykaz, Status stan)
        {
            bool usuniete = false;

            foreach (Receipt zdarzenie in WykazAndZdarzenieAndOpisStanu(wykaz, stan))
            {
                this.repository.DeleteZdarzenie(zdarzenie);
                usuniete = true;
            }
            return usuniete;
        }

    }
}

