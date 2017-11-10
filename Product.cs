using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Adgistics_Shopping_Basket
{
    class Product
    {
        private String id;
        private String name;
        private Double price;
        private Dictionary<Int64, Double> offers  = new System.Collections.Generic.Dictionary<Int64, Double>();


        public Product(String id, String name, Double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            offers[1] = price;
        }

        public String getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public Double getPrice()
        {
            return price;
        }

        public String toString()
        {
            return getId() + " - " + getName();
        }

        public void addOffer(Int64 quantity, Double price)
        {
            offers[quantity] = price;
        }

        public void removeOffer(Int64 quantity)
        {
            offers.Remove(quantity);
        }

        public Double getCost(Int64 quantity)
        {
            Double lowestCost = 0;
            foreach (KeyValuePair<Int64, Double> offer in offers)
            {
                Int64 numberOfOffer = quantity / offer.Key;
                Int64 numberOfRegularPrice = quantity % offer.Key;

                Double cost = numberOfOffer * offer.Value + numberOfRegularPrice * price;

                if (lowestCost == 0 || lowestCost > cost)
                {
                    lowestCost = cost;
                }
                
            }
            return lowestCost;
        }

    }
}
