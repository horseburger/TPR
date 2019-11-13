using System;

namespace Bookstore.Objects
{
    public class Borrow : Purchase
    {

        private DateTime borrowDate;
        private DateTime returnDate;

        public DateTime BorrowDate
        {
            get => borrowDate;
            set => borrowDate = value;
        }

        public DateTime ReturnDate
        {
            get => returnDate;
            set => returnDate = value;
        }

        public Borrow(Client who, DateTime borrowDate) : base(who)
        {
            this.borrowDate = borrowDate;
        }
    }
}