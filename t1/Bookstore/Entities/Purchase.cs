using System;

namespace Bookstore.Objects
{
    public class Purchase : Event
    {
        private Double price;

        public Double Price { get; set;}

        public Purchase()
        {
        }
        public Purchase(Client who, Status statusInfo, DateTime date, Double price) : base(who, statusInfo, date)
        {
            this.price = price;
        }
    }
}