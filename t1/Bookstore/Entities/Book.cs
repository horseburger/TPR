using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bookstore.Objects
{
    [Serializable]
    public class Book
    {
        private int _id;
        private string info;

        private List<Event> events;

        public List<Event> Events
        {
            get => events;
            set => events = value;
        }
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Info => info;

        public Book(int id, string info)
        {
            this.info = info;
            this._id = id;
            this.events = new List<Event>();
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Id == book.Id &&
                   Info == book.Info;
        }

        public override int GetHashCode()
        {
            var hashCode = 227837733;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Info);
            return hashCode;
        }

        public override string ToString()
        {
            return Id + ":" + Info;
        }
    }
}