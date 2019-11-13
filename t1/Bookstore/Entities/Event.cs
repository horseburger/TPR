using System;
using Bookstore.Objects;

namespace Bookstore
{
    [Serializable]
    public class Event
    {
        private Client who;
        private Status statusInfo;
        private DateTime date;

        public Client Who { get => who; set => who = value; }
        public Status StatusInfo { get => statusInfo; set => statusInfo = value; }
        public DateTime Date{ get => date; set => date = value; }


        public Event()
        {

        }
        public Event(Client who, Status statusInfo, DateTime date)
        {
            Who = who;
            StatusInfo = statusInfo;
            Date = date;

        }
    }
}
