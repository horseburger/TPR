using System;
using part_one;

namespace part_two
{
    public class WypelnianieDanymi : DataFiller
    {
        public void Fill(DataContext context)
        {
            Klient w = new Klient("Kamilek", "Glik");
            Ksiazka k;
            OpisStanu oS;
            for (int i = 0; i < 10; i++)
            {
                k = new Ksiazka(i, "ABC");
                oS = new OpisStanu(k, i);
                context.katalogDict.Add(k.Id, k);
                context.wykazList.Add(w);
                context.zdarzenieCollection.Add(new Zdarzenie(w, DateTime.Now, oS));
                context.statusInfoList.Add(oS);
            }
        }
}
}