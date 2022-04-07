using System;
using System.Text;

namespace meatShop.Logic
{
    public class UltimateWarrior
    {
        int Id { get; set; }

        int OrderId { get; set; }

        int StoreId { get; set; }

        int CustomerId { get; set; }

        string OrderPlaced { get; set; }

        string ProductName { get; set; }

        int ProductAmount { get; set; }

        int ItemListId { get; set; }

        int StoreId2 { get; set; }

        string StoreName { get; set; }

        string location { get; set; }

        int StoreHistoryId2 { get; set; }

        int ItemListId2 { get; set; }


        public UltimateWarrior()
        {
        }


        public UltimateWarrior(int Id, int OrderId, int StoreId, int CustomerId, string OrderPlaced, string ProductName, int ProductAmount, int ItemListId, int StoreId2, string StoreName, string location, int StoreHistoryId2, int ItemListId2)

        {
            this.Id = Id;
            this.OrderId = OrderId;
            this.StoreId = StoreId;
            this.CustomerId = CustomerId;
            this.OrderPlaced = OrderPlaced;
            this.ProductName = ProductName;
            this.ProductAmount = ProductAmount;
            this.ItemListId = ItemListId;
            this.StoreId2 = StoreId2;
            this.StoreName = StoreName;
            this.location = location;
            this.StoreHistoryId2 = StoreHistoryId2;
            this.ItemListId2 = ItemListId2;


        }


        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"This {this.Id},OrderId:{this.OrderId}, storeId: {this.StoreId}, CustomerId: {this.CustomerId}, OrderPlaced{this.OrderPlaced}, ProductName {this.ProductName}, ProductAmount{this.ProductAmount}, ItemlistID {this.ItemListId},Name{this.StoreName} Location: {this.location}.");
            return sb.ToString();
        }
    }
}
