using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using part_one;
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

        //Wyświetl
        public void Wyswietl(List<Wykaz> wykazy)
        {
            foreach(Wykaz wykaz in wykazy)
            {
                Console.WriteLine(wykaz.ToString());
            }
        }

        public void Wyswietl(Dictionary<int, Katalog> katalogi)
        {
            foreach (var item in katalogi)
            {
                Console.WriteLine("index: " + item.Key + " " + item.Value.ToString());
            }
        }

        public void Wyswietl(ObservableCollection<Zdarzenie> zdarzenia)
        {
            foreach (Zdarzenie zdarzenie in zdarzenia)
            {
                Console.WriteLine(zdarzenie.ToString());
            }
        }

        public void Wyswietl(List<OpisStanu> opisy)
        {
            foreach (OpisStanu opis in opisy)
            {
                Console.WriteLine(opis.ToString());
            }
        }

        //Dodaj
        public void DodajWykaz(Wykaz wykaz)
        {
            this.repository.AddWykaz(wykaz);
        }
        public void DodajWykaz(string name, string surname)
        {
            this.repository.AddWykaz(new Wykaz(name, surname));
        }
        public void DodajKatalog(Katalog katalog)
        {
            this.repository.AddKatalog(katalog);
        }
        public void DodajKatalog(int id, string info)
        {
            this.repository.AddKatalog(new Katalog(id, info));
        }
        public void DodajZdarzenie(Zdarzenie zdarzenie)
        {
            this.repository.AddZdarzenie(zdarzenie);
        }
        public void DodajZdarzenie(Wykaz who, DateTime borrowdate, OpisStanu statusInfo)
        {
            this.repository.AddZdarzenie(new Zdarzenie(who, borrowdate, statusInfo));
        }
        public void DodajOpisStanu(OpisStanu opis)
        {
            this.repository.AddOpisStanu(opis);
        }
        public void DodajOpisStanu(Katalog product, DateTime data_zakupu, float price)
        {
            this.repository.AddOpisStanu(new OpisStanu(product, price));
        }

        //Wyszukaj
        public List<Wykaz> SzukajWykaz(string fraza)
        {
            List<Wykaz> rezultat = new List<Wykaz>();

            foreach (Wykaz wykaz in this.repository.GetAllWykaz())
            {
                if (wykaz.ToString().Contains(fraza)) rezultat.Add(wykaz);
            }
            return rezultat;
        }

        public Dictionary<int, Katalog> SzukajKatalog(string fraza)
        {
            Dictionary<int, Katalog> rezultat = new Dictionary<int, Katalog>();

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

            foreach(OpisStanu opis in this.repository.GetAllOpisStanu())
            {
                if (opis.Price >= minPrice && opis.Price <= maxPrice) rezultat.Add(opis);
            }
            return rezultat;
        }

        //Znajdź powiązania
        public ObservableCollection<Zdarzenie> ZdarzenieAndWykaz(Wykaz wykaz)
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
        public IEnumerable<OpisStanu> OpisStanuAndKatalog(Katalog katalog)
        {
            List<OpisStanu> stany = new List<OpisStanu>();

            foreach (OpisStanu stan in this.repository.GetAllOpisStanu())
            {
                if (stan.Product.Equals(katalog)) stany.Add(stan);
            }

            return stany;
        }


    }
}

