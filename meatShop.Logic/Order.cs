using System;
using System.Text;


namespace meatShop.Logic
{
    public partial class Order
    {
        int Id { get; set; }

        int OrderId { get; set; }

        int StoreId { get; set; }

        int CustomerId { get; set; }

        string OrderPlaced { get; set; }

        string ProductName { get; set; }

        int ProductAmount { get; set; }

        int ItemListId { get; set; }

        public Order()
        {
        }

        public Order(int Id, int OrderId, int StoreId, int CustomerId, string OrderPlaced, string ProductName, int ProductAmount, int ItemListId)
        {
            this.Id = Id;
            this.OrderId = OrderId;
            this.StoreId = StoreId;
            this.CustomerId = CustomerId;
            this.OrderPlaced = OrderPlaced;
            this.ProductName = ProductName;
            this.ProductAmount = ProductAmount;
            this.ItemListId = ItemListId;

        }


        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Thisis StoreID{this.StoreId}  and I am Customer {this.CustomerId}, it was placed on {this.OrderPlaced} for {this.ProductName}");
            return sb.ToString();
        }
    }


}
