using System;
using System.Collections.Generic;
using System.IO;

namespace StoreApplication_P0.Logic
{
    public class Store
    {
        // Fields
        protected string storeLocation;
        protected string itemName;
        protected string itemCategory;
        protected decimal price;
        protected int quantity;

        // Constructors
        public Store() { }
        public Store(string itemName, string itemCategory, decimal price, int quantity)
        {
            //this.storeLocation = storeLocation;
            this.itemName = itemName;
            this.itemCategory = itemCategory;
            this.price = price;
            this.quantity = quantity;
        }

        // Methods
        public string GetStoreLocation()
        { return this.storeLocation; }
        public string GetItem()
        { return this.itemName; }
        public string GetCategory()
        { return this.itemCategory; }
        public decimal GetPrice()
        { return this.price; }
        public int GetQuantity()
        { return this.quantity; }


        public void SetItem(string itemName)
        { this.itemName = itemName; }
        public void SetCategory(string itemCategory)
        { this.itemCategory = itemCategory; }
        public void SetPrice(decimal price)
        { this.price = price; }
        public void SetQuantity(int quantity)
        { this.quantity = quantity; }
        public void SetStoreLocation(string storeLocation)
        { this.storeLocation = storeLocation; }
    }
}
