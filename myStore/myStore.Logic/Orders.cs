using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStore.Logic
{
    internal class Orders
    {
        // Fields
        int orderNum;
        int customerId;
        int storeId;
        int itemId;
        string itemName;
        double itemPrice;
        DateTime orderDate;

        // Constructors
        public Orders() { }

        public Orders( int orderNum, int custID, int storeID, int itemID, string name, double price, DateTime orderDate ) 
        {
        this.orderNum = orderNum;
        this.customerId = custID;
        this.storeId = storeID;
        this.itemId = itemID;
        this.itemName = name;
        this.itemPrice = price;
        this.orderDate = orderDate;
        }

        // Methods

    }
}
