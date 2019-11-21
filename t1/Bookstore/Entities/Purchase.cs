using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Bookstore.Entities
{
    [Serializable]
    public class Purchase : Event
    {
        private bool _method_of_payment;

        // true = cash, false = credit card
        public bool Method_of_payment { get; set;}

        public Purchase()
        {
        }
        public Purchase(Client who, Status statusInfo, DateTime date, bool methodOfPayment) : base(who, statusInfo, date)
        {
            this._method_of_payment = methodOfPayment;
        }

        public override bool Equals(object obj)
        {
            return obj is Purchase purchase &&
                   base.Equals(obj) &&
                   Method_of_payment == purchase.Method_of_payment;
        }

        public override int GetHashCode()
        {
            var hashCode = 1220326271;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Method_of_payment.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return base.ToString() + ":" + Method_of_payment;
        }

        override public string Serialization(ObjectIDGenerator idGen)
        {
            string data = this.GetType().FullName + ";";
            data += idGen.GetId(this, out bool firstTime) + ";";
            data += idGen.GetId(this.Who, out firstTime) + ";";
            data += idGen.GetId(this.StatusInfo, out firstTime) + ";";
            data += this.Date.ToString("O") + ";";
            data += this.Method_of_payment.ToString() + ";";

            return data;
        }

        override public void Deserialization(string[] data, Dictionary<int, object> objDict)
        {
            this.Who = (Client) objDict[int.Parse(data[2])];
            this.StatusInfo = (Status) objDict[int.Parse(data[3])];
            this.Date = DateTime.Parse(data[4], null, DateTimeStyles.RoundtripKind);
            this.Method_of_payment = bool.Parse(data[5]);
        }
    }
}