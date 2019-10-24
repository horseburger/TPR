using System;

namespace Bookstore.Objects
{
    public class Zdarzenie
    {
        private Klient who;
        private DateTime borrowDate;
        private DateTime returnDate;
        private OpisStanu statusInfo;

        public Klient Who { get => who; set => who = value; }
        public DateTime BorrowDate { get => borrowDate; set => borrowDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public OpisStanu StatusInfo { get => statusInfo; set => statusInfo = value; }

        public Zdarzenie(Klient who, DateTime borrowdate, OpisStanu statusinfo)
        {
            this.Who = who;
            this.BorrowDate = borrowdate;
            this.StatusInfo = statusinfo;
        }
    }
}