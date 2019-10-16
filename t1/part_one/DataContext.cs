using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace part_one
{
    public class DataContext
    {
        public List<Wykaz> wykazList { get; set; }
        public Dictionary<int, Katalog> katalogDict { get; set;  }
        public ObservableCollection<Zdarzenie> zdarzenieCollection { get; set;  }
        public List<OpisStanu> statusInfoList { get; set;  }

        public DataContext()
        {
            this.wykazList = new List<Wykaz>();
            this.katalogDict = new Dictionary<int, Katalog>();
            this.zdarzenieCollection = new ObservableCollection<Zdarzenie>();
            this.statusInfoList = new List<OpisStanu>();
        }

    }
}