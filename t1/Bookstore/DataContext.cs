using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using Bookstore.Objects;

namespace Bookstore
{
    [Serializable]
    public class DataContext : System.Runtime.Serialization.ISerializable
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

        public DataContext(SerializationInfo info, StreamingContext context)
        {
            Clients = (List<Client>) info.GetValue("clients", typeof(List<Client>));
            Books = (Dictionary<int, Book>) info.GetValue("books", typeof(Dictionary<int, Book>));
            Events = (ObservableCollection<Event>) info.GetValue("events", typeof(ObservableCollection<Event>));
            Statuses = (List<Status>) info.GetValue("statuses", typeof(List<Status>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("clients", Clients, typeof(List<Client>));
            info.AddValue("books", Books, typeof(Dictionary<int, Book>));
            info.AddValue("events", Events, typeof(ObservableCollection<Event>));
            info.AddValue("statuses", Statuses, typeof(List<Status>));
        }

        public override bool Equals(object obj)
        {
            return obj is DataContext context &&
                Clients.SequenceEqual(context.Clients) &&
                Books.SequenceEqual(context.Books) &&
                Statuses.SequenceEqual(context.Statuses) &&
                Events.All(context.Events.Contains) && Events.Count == context.Events.Count
                ;
        }

        public override int GetHashCode()
        {
            var hashCode = 1526022171;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Client>>.Default.GetHashCode(Clients);
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<int, Book>>.Default.GetHashCode(Books);
            hashCode = hashCode * -1521134295 + EqualityComparer<ObservableCollection<Event>>.Default.GetHashCode(Events);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Status>>.Default.GetHashCode(Statuses);
            return hashCode;
        }
    }
}