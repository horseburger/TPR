using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bookstore.Objects;

namespace Bookstore
{
    public class DataContext
    {
        public List<Client> Clients { get; set; }
        public Dictionary<int, Book> Books { get; set;  }
        public ObservableCollection<Event> Events { get; set;  }
        public List<Status> Statuses { get; set;  }

        public DataContext()
        {
            this.Clients = new List<Client>();
            this.Books = new Dictionary<int, Book>();
            this.Events = new ObservableCollection<Event>();
            this.Statuses = new List<Status>();
        }

    }
}