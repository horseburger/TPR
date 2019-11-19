using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Bookstore.Entities
{
    [Serializable]
    public class Borrow : Event
    {

        private DateTime _returnDate;

        public DateTime ReturnDate { get; set; }

        public Borrow(Client who, Status statusInfo, DateTime date, DateTime returnDate) : base(who, statusInfo, date)
        {
            this._returnDate = returnDate;
        }

        public Borrow()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Borrow borrow &&
                   ReturnDate == borrow.ReturnDate;
        }

        public override int GetHashCode()
        {
            return -2139873453 + ReturnDate.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString() + ":" + ReturnDate;
        }

        override public string Serialization(ObjectIDGenerator idGen)
        {
            string data = this.GetType().FullName + ",";
            data += idGen.GetId(this, out bool firstTime) + ",";
            data += idGen.GetId(this.Who, out firstTime) + ",";
            data += idGen.GetId(this.StatusInfo, out firstTime) + ",";
            data += this.Date.ToString("g") + ",";
            data += this.ReturnDate.ToString("g") + ",";

            return data;
        }

        override public void Deserialization(string[] data, Dictionary<int, object> objDict)
        {
            this.Who = (Client) objDict[int.Parse(data[2])];
            this.StatusInfo = (Status) objDict[int.Parse(data[3])];
            this.Date = DateTime.Parse(data[4]);
            this.ReturnDate = DateTime.Parse(data[5]);
        }
    }
}