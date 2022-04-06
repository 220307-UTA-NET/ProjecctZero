using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Logic
{
    public class Orders
    {
        //Fields
        private int orderLine;
        private int locationID;
        private int customerID;
        private DateTime orderPlaced;
        private int itemID;
        private int quantity;
        private int orderID;

        //Constructor
        public Orders() { }
        public Orders(int locationID)
        {
            this.locationID = locationID;
        }
        public Orders(int locationID, int customerID, int itemID, int quantity, int orderID)
        {           
            this.locationID = locationID;
            this.customerID = customerID;            
            this.itemID = itemID;
            this.quantity = quantity;
            this.orderID = orderID;
        }
        public Orders(int orderLine, int locationID, int customerID, DateTime orderPlaced, int itemID, int quantity, int orderID)
        {
            this.orderLine = orderLine;
            this.locationID = locationID;
            this.customerID = customerID;
            this.orderPlaced = orderPlaced;
            this.itemID = itemID;
            this.quantity = quantity;
            this.orderID = orderID;
        }

        //Methods
        public int GetOrderLine() { return this.orderLine; }
        public int GetLocationID() { return this.locationID; }
        public int GetCustomerID() { return this.customerID; }
        public DateTime GetOrderPlaced() { return this.orderPlaced; }
        public int GetItemID() { return this.itemID; }  
        public int GetQuantity() { return this.quantity; }
        public int GetOrderID() { return this.orderID; }
        public void SetLocationID(int locationID) { this.locationID = locationID; }
        public void SetCustomerID(int customerID) { this.customerID = customerID; }
        public void SetItemID(int itemID) { this.itemID = itemID; }
        public void SetOrderID(int orderID) { this.orderID = orderID; }
        public string GiveOTable()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"    {this.orderLine}            {this.locationID}            {this.customerID}     {this.orderPlaced}  {this.itemID}         {this.quantity}            {this.orderID}");
            return sb.ToString();
        }

    }
}
