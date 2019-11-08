using System;

namespace Bookstore.Objects
{
    public class Purchase
    {
        private Client who;
        private Status statusInfo;
        
        public Client Who { get => who; set => who = value; }
        public Status StatusInfo { get => statusInfo; set => statusInfo = value; }


        public Purchase(Client who)
        {
            this.Who = who;
        }

        public Purchase(Client who, Status status)
        {
            this.who = who;
            this.statusInfo = status;
        }
    }
}