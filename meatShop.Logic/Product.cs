using System;
using System.Text;
namespace meatShop.Logic
{
    public class Product
    {
        int ProductId { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        double Price { get; set; }

        int Amount { get; set; }

        int ItemListId { get; set; }


        public Product()
        {
        }
        
        public Product(int ProductId, string Name, string Description, double Price, int Amount, int ItemListId)
        {
            this.ProductId = ProductId;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Amount = Amount;
            this.ItemListId = ItemListId;
        }


        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, this item is {this.Name} , and it's ID is: {this.ProductId}. Price: {this.Price}. Cost: {this.Amount}");
            return sb.ToString();
        }
    }
}
