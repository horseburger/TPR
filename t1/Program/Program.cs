﻿using System;
using System.IO;
using Bookstore;
using Bookstore.Entities;
using CustomSerializer;

namespace Program
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string filename = "file";
            DataRepository repo = new DataRepository(new CustomFiller());
            repo.Api.Fill(repo.GetStorage());
            Serializer serializer = new Serializer();
            string json = serializer.SerializeItemJson(repo.GetStorage());
            Console.WriteLine(json);
            serializer.SerializeItemJson(filename + ".json", repo.GetStorage());
            serializer.SerializeItemBinary(filename + ".data", repo.GetStorage());
            serializer.Serialize(new FileStream(filename + ".custom", FileMode.Create), repo.Storage);
            DataContext c1 = serializer.DeserializeItemJson(json);
            DataContext c2 = serializer.DeserializeItemJsonFromFile(filename + ".json");
            DataContext c3 = serializer.DeserializeItemBinary(filename + ".data");


            Console.WriteLine("Original repo and c1: " + CheckIfSame(repo.GetStorage(), c1));
            Console.WriteLine("Original repo and c2: " + CheckIfSame(repo.GetStorage(), c2));
            Console.WriteLine("Original repo and c3: " + CheckIfSame(repo.GetStorage(), c3));
        }

        private static bool CheckIfSame(DataContext c1, DataContext c2)
        {
            if (c1.Clients.Count == c2.Clients.Count)
            {
                for (int i = 0; i < c1.Clients.Count; i++)
                {
                    if (!c1.Clients[i].Equals(c2.Clients[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }

    public class CustomFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            Book book;
            Status status;
            Client client;
            Event purchase;
            for (int i = 0; i < 10; i++)
            {
                book = new Book(i, "this is a book");
                status = new Status(book, 10 + i);
                client = new Client("Kamil" + i.ToString(), "Glik");
                purchase = new Purchase(client, status, DateTime.Now.AddDays(i), false);
                context.Books.Add(book.Id, book);
                context.Statuses.Add(status);
                context.Clients.Add(client);
                context.Events.Add(purchase);
            }
        }
    }

    public class CustomFiller2 : IDataFiller
    {
        public void Fill(DataContext context)
        {
            Book book = new Book(0, "this is a book");
            Status status = new Status(book, 39.99f);
            Client client = new Client("Kamil", "Glik");
            Client client2 = new Client("Ireneusz", "Jeleń");
            Event purchase = new Purchase(client, status, DateTime.Now, false);
            Event borrow = new Borrow(client2, status, DateTime.Now, DateTime.Now.AddMonths(1));
            book.Events.Add(purchase);
            book.Events.Add(borrow);
            for (int i = 0; i < 10; i++)
            {
                context.Books.Add(i, book);
                context.Clients.Add(client);
                context.Clients.Add(client2);
                context.Events.Add(purchase);
                context.Events.Add(borrow);
                context.Statuses.Add(status);
            }
        }
    }
}