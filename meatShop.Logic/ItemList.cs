using System;
using System.Text;
namespace meatShop.Logic
{
    public class ItemList
    {
        int Id { get; set; }

        int ItemListId { get; set; }

        int ProductId { get; set; }

        int StoreId { get; set; }

        int OrderId { get; set; }

        int Amount { get; set; }

        public ItemList()
        {
        }

        public ItemList(int Id, int ItemListId, int ProductId, int StoreId, int OrderId, int Amount)
        {
            this.Id = Id;
            this.ItemListId = ItemListId;
            this.ProductId = ProductId;
            this.StoreId = StoreId;
            this.OrderId = OrderId;
            this.Amount = Amount;
        }

        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, this ItemList {this.ItemListId} has ProductId:{this.ProductId} StoreId: {this.StoreId} OrderID: {this.OrderId}, Amount {this.Amount}and it's ID is: {this.Id}");
            return sb.ToString();
        }

    }
}
