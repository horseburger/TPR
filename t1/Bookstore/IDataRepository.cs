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
         void AddBook(Book book);
         Book GetBook(int id);
         Dictionary<int, Book> GetAllBooks();
         void UpdateBook(int id, Book book);
         bool DeleteBook(Book book);
         void AddClient(Client element);
         Client GetClient(int id);
         List<Client> GetAllClient();
         void UpdateClient(int id, Client element);
         bool DeleteClient(Client element);
         void AddEvent(Event purchase);
         Event GetEvent(int id);
         ObservableCollection<Event> GetAllEvents();
         void UpdateEvent(int id, Event element);
         bool DeleteEvent(Event element);
         void AddStatus(Status status);
         Status GetStatus(int id);
         List<Status> GetAllStatus();
         void UpdateStatus(int id, Status status);
         bool DeleteStatus(Status element);
    }
