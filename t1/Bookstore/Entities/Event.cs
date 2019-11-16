using System;
using System.Collections.Generic;
using Bookstore.Objects;
using Newtonsoft.Json;

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

        public override bool Equals(object obj)
        {
            return obj is Event evt &&
                   Who.Equals(evt.Who) &&
                   StatusInfo.Equals(evt.StatusInfo) &&
                   Date.Equals(evt.Date);
        }

        public override int GetHashCode()
        {
            var hashCode = 1131847275;
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(Who);
            hashCode = hashCode * -1521134295 + EqualityComparer<Status>.Default.GetHashCode(StatusInfo);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return Who + ":" + StatusInfo + Date;
        }
    }
}
