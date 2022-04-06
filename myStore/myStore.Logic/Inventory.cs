using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStore.Logic
{
    public class Inventory
    {
        // Fields
        int invKey;
        int itemId;
        string itemName;
        decimal itemPrice;
        int qty;

        // Constructor
        public Inventory() { }
        public Inventory(int itemId, string itemName, decimal itemPrice, int qty) 
        {
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.qty = qty;

        }

        // Methods
        public int GetinvKey()
        { return this.invKey; }
        public int GetitemId()
        { return this.itemId; }
        public string GetitemName()
        { return this.itemName; }
        public decimal GetitemPrice()
        { return this.itemPrice; }
        public int Getqty()
        { return this.qty; }

        public string ListInventory()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"[itemId]: {this.itemId}         [itemName]: {this.itemName}         [itemPrice:] {this.itemPrice}          [qty]: {this.qty}");
            return sb.ToString();
        }

    }
}
