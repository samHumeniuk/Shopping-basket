using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adgistics_Shopping_Basket
{
    class Offer
    {
        private Int64 quantity;
        private Double price;

        public Offer(Int64 quantity, Double price)
        {
            this.quantity = quantity;
            this.price = price;
        }
    }
}
