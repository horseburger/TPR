using System;
using Bookstore.Objects;

namespace Bookstore
{
    public class DataFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            Client w = new Client("Kamilek", "Glik");
            Book k;
            Status oS;
            for (int i = 0; i < 10; i++)
            {
                k = new Book(i, "ABC");
                oS = new Status(k, i);
                context.Books.Add(k.Id, k);
                context.Clients.Add(w);
                context.Receipts.Add(new Receipt(w, DateTime.Now, oS));
                context.Statuses.Add(oS);
            }
        }
}
}