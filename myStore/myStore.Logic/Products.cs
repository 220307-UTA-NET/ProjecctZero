using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStore.Logic
{
    internal class Product
    {
        // Fields
        int itemId;
        string itemName;
        double itemPrice;

        // Constructors
        public Product() { }
        public Product( int ID, string name, double price )
        {
            this.itemId = ID;
            this.itemName = name;
            this.itemPrice = price;
        }

        // Methods

    }
}
