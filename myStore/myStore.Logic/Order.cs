using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStore.Logic
{
    public class Order
    {
        int orderNum;
        int customerId;
        int storeId;
        int itemId;
        string itemName;
        decimal itemPrice;
        DateTime orderDate;

        Order() { }
        Order(int orderNum, int customerId, int storeId, int itemId, string itemName, decimal itemPrice, DateTime orderDate)
        {
            this.orderNum = orderNum;
            this.customerId = customerId;
            this.storeId = storeId;
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.orderDate = orderDate;
        }

        public int GetorderNum()
        { return this.orderNum; }
        public int GetcustomerId()
        { return this.customerId; } 
        public int GetstoreId()
        { return this.storeId; }
        public int GetitemId()
        { return this.itemId; }
        public string GetitemName()
        { return this.itemName; }
        public decimal GetitemPrice()
        { return this.itemPrice; }
        public DateTime GetorderDate()
        { return this.orderDate; }

        public string confirmOrder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.itemName} purchased for {this.customerId} from location {this.storeId} for {this.itemPrice}");
            return sb.ToString();
        }
    }
}
