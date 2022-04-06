using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalFlowStore.Logic
{
    public class Inventory
    {
        // Fields
        private int Inventory_ID;
        private string NameOfItem;
        private int Quantity;
        private int Price;
        private DateTime InventoryDateIn;
        private DateTime InventoryDateOut;

        //Constructor
        public Inventory(int Inventory_ID, string NameOfItem, int Quantity, int Price, DateTime InventoryDateIn, DateTime InventoryDateOut)
        {
            this.Inventory_ID = Inventory_ID;
            this.NameOfItem = NameOfItem;
            this.Quantity = Quantity;
            this.Price = Price;
            this.InventoryDateIn = InventoryDateIn;
            this.InventoryDateOut = InventoryDateOut;
        }

        // Methods
        public int GetInventory_ID()
        { return this.Inventory_ID; }
        public string GetNameofItem()
        { return this.NameOfItem; }
        public int GetQuantity()
        { return this.Quantity; }
        public int GetPrice()
        { return this.Price; }
        public DateTime GetInventoryDateIn()
        { return this.InventoryDateIn; }
        public DateTime GetInventoryDateOut()
        { return this.InventoryDateOut; }

        public void SetQuantity(int Quantity)
        { this.Quantity = Quantity; }
        public void SetPrice(int Price)
        { this.Price = Price; }


       
    }
}
