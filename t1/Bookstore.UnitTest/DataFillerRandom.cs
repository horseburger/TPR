using System;
using System.Linq;
using Bookstore.Objects;

namespace Bookstore.UnitTest
{
    public class DataFillerRandom : IDataFiller
    {
        private int number;

        public DataFillerRandom(int number)
        {
            this.number = number;
        }
        public void Fill(DataContext context)
        {
            Client w;
            Book k;
            Status s;
            Event z;
            
            for (int i = 0; i < number; i++)
            {
                k = new Book(i, GenerateRandomString());
                w = new Client(GenerateRandomString(), GenerateRandomString());
                s = new Status(k, new Random().Next());
                z = new Purchase(w, s, DateTime.Now, );
                context.Books.Add(i, k);
                context.Clients.Add(w);
                context.Events.Add(z);
                context.Statuses.Add(s);
            }
        }

        private string GenerateRandomString()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, this.number).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}