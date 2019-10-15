using System;
using part_one;

namespace part_two
{
    public class WypelnianieDanymi : API
    {
        public void fillWithData(DataRepository repo)
        {
            Wykaz w = new Wykaz("Kamilek", "Glik");
            Katalog k;
            OpisStanu oS;
            for (int i = 0; i < 10; i++)
            {
                k = new Katalog(i, "ABC");
                oS = new OpisStanu(k, i);
                repo.Storage.katalogDict.Add(k.Id, k);
                repo.Storage.wykazList.Add(w);
                repo.Storage.zdarzenieCollection.Add(new Zdarzenie(w, DateTime.Now, oS));
                repo.Storage.statusInfoList.Add(oS);
            }
        }
}
}