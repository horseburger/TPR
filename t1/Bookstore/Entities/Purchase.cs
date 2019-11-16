using System;

namespace Bookstore.Objects
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
    }
}