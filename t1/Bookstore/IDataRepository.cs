using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bookstore;
using Bookstore.Objects;


public interface IDataRepository
    {
        DataContext Storage { get; set; }
        IDataFiller Api { get; set; }

        event EventHandler ReceiptAdded;
        event EventHandler ReceiptRemoved;
         void AddKsiazka(Book pozycja);
         Book GetKsiazka(int id);
         Dictionary<int, Book> GetAllKsiazka();
         void UpdateKsiazka(int id, Book pozycja);
         bool DeleteKsiazka(Book pozycja);
         void AddKlient(Client element);
         Client GetKlient(int id);
         List<Client> GetAllKlient();
         void UpdateKlient(int id, Client element);
         bool DeleteKlient(Client element);
         void AddZdarzenie(Receipt receipt);
         Receipt GetZdarzenie(int id);
         ObservableCollection<Receipt> GetAllZdarzenie();
         void UpdateZdarzenie(int id, Receipt element);
         bool DeleteZdarzenie(Receipt element);
         void AddOpisStanu(Status opis);
         Status GetOpisStanu(int id);
         List<Status> GetAllOpisStanu();
         void UpdateOpisStanu(int id, Status stan);
         bool DeleteOpisStanu(Status element);
    }
