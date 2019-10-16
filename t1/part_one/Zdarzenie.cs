using System;

namespace part_one
{
    public class Zdarzenie
    {
        private Wykaz who;
        private DateTime borrowDate;
        private DateTime returnDate;
        private OpisStanu statusInfo;

        public Wykaz Who { get => who; set => who = value; }
        public DateTime BorrowDate { get => borrowDate; set => borrowDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public OpisStanu StatusInfo { get => statusInfo; set => statusInfo = value; }

        public Zdarzenie(Wykaz who, DateTime borrowdate, OpisStanu statusinfo)
        {
            this.Who = who;
            this.BorrowDate = borrowdate;
            this.StatusInfo = statusinfo;
        }
    }
}