using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplication.Logic
{
    public class Product
    {

        // Fields
        private int ProductID;
        public string ProductType;
        private string ProductName;
        private int Quantity;
        private decimal Cost;

        // Parametized construtor
        public Product(int productID, string productType, string productName, int quantity, decimal cost)
        {
            this.ProductID = productID;
            this.ProductType = productType;
            this.ProductName = productName;
            this.Quantity = quantity;
            this.Cost = cost;
        }


        public Product()
        {
            this.ProductID = 0;
            this.ProductType = "";
            this.ProductName = "";
            this.Quantity = 0;
            this.Cost = 0;
        }

        public int GetProductID() { return this.ProductID; }
        public string GetProductType() { return this.ProductType; }
        public string GetProductName() { return this.ProductName; }
        public int GetQuantity() { return this.Quantity; }
        public decimal GetCost() { return this.Cost; }
   

        public string getProduct()
        {
            string str = "";
            str += this.ProductType.ToString() + "\t" + this.ProductName.ToString() + "\n";
            str += "\t\t" + "unit price :    " + this.Cost.ToString() + "\n";
            str += "\t\t" + "quantity   :    " + this.Quantity.ToString() + "\n";
            str += "\t\t" + "total   :    " + (this.Quantity * this.Cost).ToString() + "\n";
            return str;
        }
    }
}
