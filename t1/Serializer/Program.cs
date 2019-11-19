using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;
using Bookstore.Objects;

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
            DataContext c1 = serializer.DeserializeItemJson(json);
            DataContext c2 = serializer.DeserializeItemJsonFromFile(filename + ".json");
            DataContext c3 = serializer.DeserializeItemBinary(filename + ".data");

            Console.WriteLine("Original repo and c1: " + CheckIfSame(repo.GetStorage(), c1));
            Console.WriteLine("Original repo and c2: " + CheckIfSame(repo.GetStorage(), c2));
//            Console.WriteLine("Original repo and c3: " + CheckIfSame(repo.GetStorage(), c3));

            string obj = repo.Storage.Books[0].Serialization(new ObjectIDGenerator());
            char[] separator = {','};
            Book book = new Book();
            book.Deserialization(obj.Split(separator));
            Console.WriteLine(book);

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
            Book book = new Book(0, "this is a book");
            Status status = new Status(book, 39.99f);
            Client client = new Client("Kamil", "Glik");
            Event purchase = new Purchase(client, status, DateTime.Now, false);
            for (int i = 0; i < 10; i++)
            {
                context.Books.Add(i, book);
                context.Clients.Add(client);
                context.Events.Add(purchase);
                context.Statuses.Add(status);
            }
        }
    }
}