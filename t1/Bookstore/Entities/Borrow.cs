using System;

namespace Bookstore.Objects
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
    }
}