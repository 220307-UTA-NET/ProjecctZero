using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStore.Logic
{
    internal class SeattleInventory
    {
        // Fields
        int invKey;
        int itemId;
        string itemName;
        decimal itemPrice;
        int qtySEA;

        // Constructors
        public SeattleInventory() { }
        public SeattleInventory(int ID, string name, decimal price, int qty)
        {
            this.itemId = ID;
            this.itemName = name;
            this.itemPrice = price;
            this.qtySEA = qty;
        }

        // Methods
        public string ListInventory()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"[itemId]: {this.itemId}         [itemName]: {this.itemName}         [itemPrice:] {this.itemPrice}          [qty]: {this.qtySEA}");
            return sb.ToString();
        }

    }
}
