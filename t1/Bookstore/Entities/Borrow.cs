using System;

namespace Bookstore.Objects
{
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
    }
}