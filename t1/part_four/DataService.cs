﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using part_one;
using Newtonsoft.Json;
using part_two;

namespace part_four
{
    class DataService
    {
        private DataRepository repository;

        public DataService(DataRepository repository)
        {
            this.repository = repository;
        }

        //Zwróć
        public string Zwroc(List<Klient> wykazy)
        {
            return JsonConvert.SerializeObject(wykazy);
        }

        public string Zwroc(Dictionary<int, Ksiazka> katalogi)
        {
            return JsonConvert.SerializeObject(katalogi);
        }

        public string Zwroc(ObservableCollection<Zdarzenie> zdarzenia)
        {
            return JsonConvert.SerializeObject(zdarzenia);
        }

        public string Zwroc(List<OpisStanu> opisy)
        {
            return JsonConvert.SerializeObject(opisy);
        }

        //Dodaj
        public void DodajWykaz(Klient wykaz)
        {
            this.repository.AddWykaz(wykaz);
        }
        public void DodajWykaz(string name, string surname)
        {
            this.repository.AddWykaz(new Klient(name, surname));
        }
        public void DodajKatalog(Ksiazka katalog)
        {
            this.repository.AddKatalog(katalog);
        }
        public void DodajKatalog(int id, string info)
        {
            this.repository.AddKatalog(new Ksiazka(id, info));
        }
        public void DodajZdarzenie(Zdarzenie zdarzenie)
        {
            this.repository.AddZdarzenie(zdarzenie);
        }
        public void DodajZdarzenie(Klient who, DateTime borrowdate, OpisStanu statusInfo)
        {
            this.repository.AddZdarzenie(new Zdarzenie(who, borrowdate, statusInfo));
        }
        public void DodajOpisStanu(OpisStanu opis)
        {
            this.repository.AddOpisStanu(opis);
        }
        public void DodajOpisStanu(Ksiazka product, DateTime data_zakupu, float price)
        {
            this.repository.AddOpisStanu(new OpisStanu(product, price));
        }

        //Wyszukaj
        public List<Klient> SzukajWykaz(string fraza)
        {
            List<Klient> rezultat = new List<Klient>();

            foreach (Klient wykaz in this.repository.GetAllWykaz())
            {
                if (wykaz.ToString().Contains(fraza)) rezultat.Add(wykaz);
            }
            return rezultat;
        }

        public Dictionary<int, Ksiazka> SzukajKatalog(string fraza)
        {
            Dictionary<int, Ksiazka> rezultat = new Dictionary<int, Ksiazka>();

            foreach (var item in this.repository.GetAllKatalog())
            {
                if (item.Value.ToString().Contains(fraza)) rezultat.Add(item.Key, item.Value);
            }
            return rezultat;
        }
        public ObservableCollection<Zdarzenie> SzukajZdarzenia(DateTime borrowDate, DateTime returnDate)
        {
            ObservableCollection<Zdarzenie> rezultat = new ObservableCollection<Zdarzenie>();

            foreach (Zdarzenie zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.BorrowDate > borrowDate && zdarzenie.ReturnDate < returnDate) rezultat.Add(zdarzenie);
            }
            return rezultat;
        }
        public ObservableCollection<Zdarzenie> SzukajZdarzenia(DateTime borrowDate)
        {
            ObservableCollection<Zdarzenie> rezultat = new ObservableCollection<Zdarzenie>();

            foreach (Zdarzenie zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.BorrowDate > borrowDate) rezultat.Add(zdarzenie);
            }
            return rezultat;
        }
        public List<OpisStanu> SzukajOpisStanu(float minPrice, double maxPrice)
        {
            List<OpisStanu> rezultat = new List<OpisStanu>();

            foreach (OpisStanu opis in this.repository.GetAllOpisStanu())
            {
                if (opis.Price >= minPrice && opis.Price <= maxPrice) rezultat.Add(opis);
            }
            return rezultat;
        }

        //Znajdź powiązania
        public ObservableCollection<Zdarzenie> ZdarzenieAndWykaz(Klient wykaz)
        {
            ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();

            foreach (Zdarzenie zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.Who.Equals(wykaz)) zdarzenia.Add(zdarzenie);
            }

            return zdarzenia;
        }

        public ObservableCollection<Zdarzenie> ZdarzeniaAndOpisStanu(OpisStanu stan)
        {

            ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();

            foreach (Zdarzenie zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.StatusInfo.Equals(stan)) zdarzenia.Add(zdarzenie);
            }

            return zdarzenia;
        }
        public ObservableCollection<Zdarzenie> WykazAndZdarzenieAndOpisStanu(Klient wykaz, OpisStanu stan)
        {
            ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();

            foreach (Zdarzenie zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.StatusInfo.Equals(stan) && zdarzenie.Who.Equals(wykaz)) zdarzenia.Add(zdarzenie);
            }
            return zdarzenia;
        }
        public List<OpisStanu> OpisStanuAndKatalog(Ksiazka katalog)
        {
            List<OpisStanu> stany = new List<OpisStanu>();

            foreach (OpisStanu stan in this.repository.GetAllOpisStanu())
            {
                if (stan.Product.Equals(katalog)) stany.Add(stan);
            }

            return stany;
        }

        //Usuwanie
        public bool UsunWykaz(Klient wykaz)
        {
            return this.repository.DeleteWykaz(wykaz);
        }

        public bool UsunKatalog(Ksiazka katalog)
        {
            return this.repository.DeleteKatalog(katalog);
        }

        public bool UsunOpisStanu(OpisStanu stan)
        {
            return this.repository.DeleteOpisStanu(stan);
        }

        public bool UsunZdarzenie(Zdarzenie zdarzenie)
        {
            return this.repository.DeleteZdarzenie(zdarzenie);
        }
        public bool UsunZdarzenie(Klient wykaz, OpisStanu stan)
        {
            bool usuniete = false;

            foreach (Zdarzenie zdarzenie in WykazAndZdarzenieAndOpisStanu(wykaz, stan))
            {
                this.repository.DeleteZdarzenie(zdarzenie);
                usuniete = true;
            }
            return usuniete;
        }

    }
}

