using System;

namespace Bookstore.Objects
{
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
    }
}