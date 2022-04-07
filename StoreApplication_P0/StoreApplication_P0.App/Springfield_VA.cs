using System;
using System.Collections.Generic;
using System.IO;

// has OrderHistory field
// has its own list of customers

namespace StoreApplication_P0.App
{
    public class Springfield_VA : Store
    {
        // Fields



        // Constructors
        Springfield_VA( string itemName, string itemCategory, decimal price, int quantity, string storeLocation) : base( itemName, itemCategory, price, quantity)
        {
            this.storeLocation = "Springfield_VA";
        }



        // Methods


    }
}
