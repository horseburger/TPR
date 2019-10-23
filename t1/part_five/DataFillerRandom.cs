using System;
using System.Linq;
using part_one;

namespace part_five
{
    public class DataFillerRandom : DataFiller
    {
        private int number;

        public DataFillerRandom(int number)
        {
            this.number = number;
        }
        public void Fill(DataContext context)
        {
            Klient w;
            Ksiazka k;
            OpisStanu s;
            Zdarzenie z;
            
            for (int i = 0; i < number; i++)
            {
                k = new Ksiazka(i, GenerateRandomString());
                w = new Klient(GenerateRandomString(), GenerateRandomString());
                s = new OpisStanu(k, new Random().Next());
                z = new Zdarzenie(w, DateTime.Now, s);
                context.katalogDict.Add(i, k);
                context.wykazList.Add(w);
                context.zdarzenieCollection.Add(z);
                context.statusInfoList.Add(s);
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