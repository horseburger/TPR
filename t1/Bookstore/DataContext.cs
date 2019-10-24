using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bookstore.Objects
{
    public class DataContext
    {
        public List<Klient> wykazList { get; set; }
        public Dictionary<int, Ksiazka> katalogDict { get; set;  }
        public ObservableCollection<Zdarzenie> zdarzenieCollection { get; set;  }
        public List<OpisStanu> statusInfoList { get; set;  }

        public DataContext()
        {
            this.wykazList = new List<Klient>();
            this.katalogDict = new Dictionary<int, Ksiazka>();
            this.zdarzenieCollection = new ObservableCollection<Zdarzenie>();
            this.statusInfoList = new List<OpisStanu>();
        }

    }
}