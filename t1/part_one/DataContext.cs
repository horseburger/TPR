using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace part_one
{
    public class DataContext
    {
        public List<Wykaz> wykazList = new List<Wykaz>();
        public Dictionary<int, Katalog> katalogDict = new Dictionary<int, Katalog>();
        public ObservableCollection<Zdarzenie> zdarzenieCollection = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> statusInfoList = new List<OpisStanu>();

    }
}