using System;
using Bookstore;
using Bookstore.Objects;

namespace Serializer.UnitTest
{
    public class FillerForTest : IDataFiller
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
                context.Events.Add(purchase);
                context.Statuses.Add(status);
            }
        }
    }
}
