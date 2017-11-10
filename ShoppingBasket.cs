using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adgistics_Shopping_Basket
{
    class ShoppingBasket
    {
        private Dictionary<Product, Int64> basket = new System.Collections.Generic.Dictionary<Product, Int64>();

        public ShoppingBasket()
        {

        }

        public void addItem(Product product)
        {
            addItem(product, 1);
        }

        public void addItem(Product product, Int64 quantity)
        {
            if (basket.ContainsKey(product))
            {
                basket[product] = basket[product] + quantity;
            }
            else
            {
                basket[product] = quantity;
            }
        }

        public String formatPrice(Double price)
        {
            return price.ToString("0.00");
        }

        public String getPrices()
        {
            String pricesString = "";
            Double totalCost = 0;
            foreach (KeyValuePair<Product, Int64> item in basket)
            {
                Product product = item.Key;
                Int64 quantity = item.Value;
                Double expectedCost = product.getPrice() * quantity;
                Double cost = product.getCost(quantity);
                pricesString = pricesString + product.toString() + ": £" + formatPrice(product.getPrice()) + " x " + quantity + " = £" + formatPrice(expectedCost) + "\n";

                double offerSaving = expectedCost - cost;
                if (offerSaving > 0)
                {
                    pricesString = pricesString + product.toString() + " OFFER: -£" + formatPrice(offerSaving) + "\n";
                }
                totalCost = totalCost + cost;
            }
            pricesString = pricesString + "Total: £" + formatPrice(totalCost);
            return pricesString;
        }
    }
}
