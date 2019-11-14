using System;
using System.IO;
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
            string filename = "abc";
            IFormatter formatter = new Serializer();
            DataRepository repo = new DataRepository(new Filler());
            repo.Api.Fill(repo.GetStorage());
            Serializer.SerializeItem(filename, formatter, repo.GetStorage());
            DataContext c = Serializer.DeserializeItem(filename, formatter);
            Console.WriteLine(c.Clients[0].Name + ' ' + c.Clients[0].Surname);
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