using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Logic
{
    public class StoreLocation
    {
        //Fields
        private string product;
        private string locationName;
        private int inventory;
        private int quantityOrdered;
        
        
        //Constructors
        public StoreLocation(){}
        public StoreLocation(string product, int inventory, int quantityordered, string locationname)
        {
            this.product = product;
            this.locationName = locationname;
            this.inventory = inventory;
            this.quantityOrdered = quantityordered;
            
        }
        
        //Methods
        public string GetProduct(string product)
        { return this.product; }
        public string GetLocationName(string locationname)
        { return this.locationName; }
        public int GetInventory(int inventory)
        { return this.inventory; }
        public int GetQuantityOrdered(int quantityordered)
        { return this.quantityOrdered; }

        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.product} {this.inventory} {this.quantityOrdered} {this.locationName}");
            return sb.ToString();
        }


    }
}
