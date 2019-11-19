using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;
using Bookstore.Entities;

namespace Serializer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string filename = "file";
            DataRepository repo = new DataRepository(new Filler());
            repo.Api.Fill(repo.GetStorage());
            Serializer serializer = new Serializer();
            string json = serializer.SerializeItemJson(repo.GetStorage());
            Console.WriteLine(json);
            serializer.SerializeItemJson(filename + ".json", repo.GetStorage());
            serializer.SerializeItemBinary(filename + ".data", repo.GetStorage());
            serializer.Serialize(filename + ".custom", repo.GetStorage());
            DataContext c1 = serializer.DeserializeItemJson(json);
            DataContext c2 = serializer.DeserializeItemJsonFromFile(filename + ".json");
            DataContext c3 = serializer.DeserializeItemBinary(filename + ".data");
            DataContext c4 = serializer.Deserialize(filename + ".custom");


            Console.WriteLine("Original repo and c1: " + CheckIfSame(repo.GetStorage(), c1));
            Console.WriteLine("Original repo and c2: " + CheckIfSame(repo.GetStorage(), c2));
            Console.WriteLine("Original repo and c3: " + CheckIfSame(repo.GetStorage(), c3));
            Console.WriteLine("Original repo and c4: " + CheckIfSame(repo.GetStorage(), c4));


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

    public class Filler : IDataFiller
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
}