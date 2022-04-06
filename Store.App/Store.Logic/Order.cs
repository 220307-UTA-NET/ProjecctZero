using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Logic
{
    public class Order
    {
        string location;
        string item;
        double price;
        int quantity;



        public Order()
        {

        }

        public Order(string item, double price, int quantity) //Initialize an order
        {
            this.item = item;
            this.price = price;
            this.quantity = quantity;
        }





    }
}
