using System;
using System.Collections.Generic;
using System.IO;

// has OrderHistory field
// has its own list of customers

namespace StoreApplication_P0.App
{
    public class Washington_DC : Bakery
    {
        // Fields



        // Constructors
        public Washington_DC (string itemName, string itemCategory, decimal price, int quantity) : base(itemName, itemCategory, price, quantity)
        {
            this.storeLocation = "Washington_DC";
        }



        //// Methods
        //void SetStoreLocation(string storeLocation)
        //{ this.storeLocation = storeLocation; }



        //Springfield_VA;



    }
}
