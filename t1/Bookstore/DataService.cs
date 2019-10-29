﻿using System;
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

        public event EventHandler ReceiptAdded
        {
            add => repository.ReceiptAdded += value;
            remove => repository.ReceiptAdded -= value;
        }
        
        public event EventHandler ReceiptRemoved
        {
            add => repository.ReceiptRemoved += value;
            remove => repository.ReceiptRemoved -= value;
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

        public string Get(ObservableCollection<Receipt> receipts)
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
            this.repository.AddKlient(client);
        }
        public void AddClient(string name, string surname)
        {
            this.repository.AddKlient(new Client(name, surname));
        }
        public void AddBook(Book book)
        {
            this.repository.AddKsiazka(book);
        }
        public void AddBook(int id, string info)
        {
            this.repository.AddKsiazka(new Book(id, info));
        }
        public void AddReceipt(Receipt receipt)
        {
            this.repository.AddZdarzenie(receipt);
        }
        public void AddReceipt(Client who, DateTime borrowdate, Status statusInfo)
        {
            this.repository.AddZdarzenie(new Receipt(who, borrowdate, statusInfo));
        }
        public void AddStatus(Status status)
        {
            this.repository.AddOpisStanu(status);
        }
        public void AddStatus(Book product, DateTime data_zakupu, float price)
        {
            this.repository.AddOpisStanu(new Status(product, price));
        }

        //Wyszukaj
        public List<Client> SearchClient(string pattern)
        {
            List<Client> rezultat = new List<Client>();

            foreach (Client wykaz in this.repository.GetAllKlient())
            {
                if (wykaz.ToString().Contains(pattern)) rezultat.Add(wykaz);
            }
            return rezultat;
        }

        public Dictionary<int, Book> SearchBook(string pattern)
        {
            Dictionary<int, Book> rezultat = new Dictionary<int, Book>();

            foreach (var item in this.repository.GetAllKsiazka())
            {
                if (item.Value.ToString().Contains(pattern)) rezultat.Add(item.Key, item.Value);
            }
            return rezultat;
        }
        public ObservableCollection<Receipt> SearchReceipt(DateTime borrowDate, DateTime returnDate)
        {
            ObservableCollection<Receipt> rezultat = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.BorrowDate > borrowDate && zdarzenie.ReturnDate < returnDate) rezultat.Add(zdarzenie);
            }
            return rezultat;
        }
        public ObservableCollection<Receipt> SearchReceipt(DateTime borrowDate)
        {
            ObservableCollection<Receipt> rezultat = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.BorrowDate > borrowDate) rezultat.Add(zdarzenie);
            }
            return rezultat;
        }
        public List<Status> SearchStatus(float minPrice, double maxPrice)
        {
            List<Status> rezultat = new List<Status>();

            foreach (Status opis in this.repository.GetAllOpisStanu())
            {
                if (opis.Price >= minPrice && opis.Price <= maxPrice) rezultat.Add(opis);
            }
            return rezultat;
        }

        //Znajdź powiązania
        public ObservableCollection<Receipt> SearchReceiptsByClient(Client client)
        {
            ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.Who.Equals(client)) receipts.Add(zdarzenie);
            }

            return receipts;
        }

        public ObservableCollection<Receipt> SearchReceiptsByStatus(Status status)
        {

            ObservableCollection<Receipt> zdarzenia = new ObservableCollection<Receipt>();

            foreach (Receipt zdarzenie in this.repository.GetAllZdarzenie())
            {
                if (zdarzenie.StatusInfo.Equals(status)) zdarzenia.Add(zdarzenie);
            }

            return zdarzenia;
        }
        public ObservableCollection<Receipt> SearchReceiptsByClientAndStatus(Client client, Status status)
        {
            ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();

            foreach (Receipt receipt in this.repository.GetAllZdarzenie())
            {
                if (receipt.StatusInfo.Equals(status) && receipt.Who.Equals(client)) receipts.Add(receipt);
            }
            return receipts;
        }
        public List<Status> SearchStatusesByBooks(Book book)
        {
            List<Status> statuses = new List<Status>();

            foreach (Status status in this.repository.GetAllOpisStanu())
            {
                if (status.Product.Equals(book)) statuses.Add(status);
            }

            return statuses;
        }

        //Usuwanie
        public bool DeleteClient(Client client)
        {
            return this.repository.DeleteKlient(client);
        }

        public bool DeleteBook(Book book)
        {
            return this.repository.DeleteKsiazka(book);
        }

        public bool DeleteStatus(Status status)
        {
            return this.repository.DeleteOpisStanu(status);
        }

        public bool DeleteReceipt(Receipt receipt)
        {
            return this.repository.DeleteZdarzenie(receipt);
        }
        public bool DeleteReceipt(Client client, Status status)
        {
            bool delete = false;

            foreach (Receipt zdarzenie in SearchReceiptsByClientAndStatus(client, status))
            {
                this.repository.DeleteZdarzenie(zdarzenie);
                delete = true;
            }
            return delete;
        }

    }
}

