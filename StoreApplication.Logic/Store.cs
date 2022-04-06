using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplication.Logic
{
    public class Store
    {
        // Fields
        private int ID;
        private string Address;
        // inventory = productID
        private int InventoryID;

        // Parametized constructor
        public Store(int ID, string address, int inventory)
        {
            this.ID = ID;
            this.Address = address;
            this.InventoryID = inventory;
        }
    }
}
