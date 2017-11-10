using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adgistics_Shopping_Basket
{
    public partial class CheckoutForm : Form
    {
        Dictionary<String, Product> catelog = new System.Collections.Generic.Dictionary<String, Product>();
        ShoppingBasket shoppingBasket = new ShoppingBasket();

        public CheckoutForm()
        {
            InitializeComponent();
            setUpShop();
        }

        private void setUpShop()
        {
            outputLabel.Text = "";

            catelog["A"] = new Product("A", "Pineapple", 5.00);
            catelog["B"] = new Product("B", "Passionfruit", 3.00);
            catelog["C"] = new Product("C", "Mango", 2.00);
            catelog["D"] = new Product("D", "Banana", 1.50);

            catelog["A"].addOffer(3, 13.00);
            catelog["B"].addOffer(2, 4.50);
            
            refreshBasket();
            
        }

        private void refreshBasket()
        {
            basketLabel.Text = shoppingBasket.getPrices();
        }

        private void AddToBasketButton_Click(object sender, EventArgs e)
        {
            String productId = (productIdTextBox.Text).ToUpper();
            if (catelog.ContainsKey(productId))
            {
                Product product = catelog[productId];
                shoppingBasket.addItem(product);
                refreshBasket();
                outputLabel.Text = "SUCCESS: " + productId + " - " + product.getName() + " added to basket";
            }
            else
            {
                outputLabel.Text = "ERROR: no product found with Id: " + productId;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}
