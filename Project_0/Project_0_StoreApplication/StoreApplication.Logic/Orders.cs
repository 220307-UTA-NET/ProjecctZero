using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Logic
{
    public class Orders
    {
        //Fields
        private int OrderID;
        private string storeLocation;
        private string customer;
       
        private string product;
        private int quantity;

        //Constructors
        public Orders(){}
        public Orders(int orderid, string product, int quantity, string customer, string storelocation )
        {
            this.OrderID = orderid;
            this.storeLocation = storelocation;
            this.customer = customer;
            
            this.product = product;
            this.quantity = quantity;
        }

        //Methods
        public string GetSL()
        { return this.storeLocation; }
        public string GetCustomer()
        { return this.customer; }
       
        public string GetProduct()
        { return this.product; }
        public int GetQuantity()
        { return this.quantity; }

        public void SetSL(string storeLocation)
        { this.storeLocation = storeLocation; }
        public void SetProduct(string product)
        { this.product = product; }
        public void SetQuantity(int quantity)
        { this.quantity = quantity; }

        public void SetCustomer(string customerName)
        { this.customer = customerName; }

        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.product} {this.quantity} {this.customer} {this.storeLocation}");
            return sb.ToString();
        }

    }
}
