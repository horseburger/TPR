using System;

namespace part_one
{
    public class Zdarzenie
    {
        private Wykaz who;
        private DateTime borrowDate, returnDate;
        private OpisStanu statusInfo;

        public Wykaz Who => who;
        public DateTime BorrowDate => borrowDate;
        public DateTime ReturnDate
        {
            get => returnDate;
            set => returnDate = value;
        }
        public OpisStanu StatusInfo => statusInfo;

        public Zdarzenie(Wykaz who, DateTime borrowDate, OpisStanu statusInfo)
        {
            this.who = who;
            this.borrowDate = borrowDate;
            this.statusInfo = statusInfo;
        }
    }
}