using System;

namespace Bookstore.Objects
{
    public class Receipt
    {
        private Client who;
        private DateTime borrowDate;
        private DateTime returnDate;
        private Status statusInfo;

        public Client Who { get => who; set => who = value; }
        public DateTime BorrowDate { get => borrowDate; set => borrowDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public Status StatusInfo { get => statusInfo; set => statusInfo = value; }

        public Receipt(Client who, DateTime borrowdate, Status statusinfo)
        {
            this.Who = who;
            this.BorrowDate = borrowdate;
            this.StatusInfo = statusinfo;
        }
    }
}