using System;
using System.Text;

namespace meatShop.Logic
{
    public class Customer_Store
    {
        int Id { get; set; }

        int StoreId { get; set; }

        int CustomerId { get; set; }

        public Customer_Store()
        {
        }

        public Customer_Store(int Id, int StoreId, int CustomerId)
        {
            this.Id = Id;
            this.StoreId = StoreId;
            this.CustomerId = CustomerId;
        }



        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, this jointable for Store and Customer {this.StoreId} , and it has {this.CustomerId}");
            return sb.ToString();
        }

    }
}
