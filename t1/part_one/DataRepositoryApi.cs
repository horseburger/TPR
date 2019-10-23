using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using part_one;


     public interface DataRepositoryApi
    {
        DataContext Storage { get; set; }
        DataFiller Api { get; set; }

        event EventHandler ZdarzenieAdded;
        event EventHandler ZdarzenieRemoved;
         void AddKsiazka(Ksiazka pozycja);
         Ksiazka GetKsiazka(int id);
         Dictionary<int, Ksiazka> GetAllKsiazka();
         void UpdateKsiazka(int id, Ksiazka pozycja);
         bool DeleteKsiazka(Ksiazka pozycja);
         void AddKlient(Klient element);
         Klient GetKlient(int id);
         List<Klient> GetAllKlient();
         void UpdateKlient(int id, Klient element);
         bool DeleteKlient(Klient element);
         void AddZdarzenie(Zdarzenie zdarzenie);
         Zdarzenie GetZdarzenie(int id);
         ObservableCollection<Zdarzenie> GetAllZdarzenie();
         void UpdateZdarzenie(int id, Zdarzenie element);
         bool DeleteZdarzenie(Zdarzenie element);
         void AddOpisStanu(OpisStanu opis);
         OpisStanu GetOpisStanu(int id);
         List<OpisStanu> GetAllOpisStanu();
         void UpdateOpisStanu(int id, OpisStanu stan);
         bool DeleteOpisStanu(OpisStanu element);
    }
