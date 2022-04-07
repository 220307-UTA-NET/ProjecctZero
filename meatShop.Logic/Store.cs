using System;
using System.Text;

namespace meatShop.Logic
{
    public class Store
    {
        /// <summary>
        /// <value> the ID for the store
        /// </summary>
        int Id { get; set; }

        string StoreName { get; set; }
        /// <summary>
        /// the name of the store
        /// </summary>
        /// 
        string Location { get; set; }

        int StoreHistoryId { get; set; }

        int ItemListId { get; set; }

        public Store()
        {
        }

        public Store(int Id, string StoreName, string Location, int StoreHistoryId,int ItemListId)
        {
            this.Id = Id;
            this.StoreName = StoreName;
            this.Location = Location;
            this.StoreHistoryId = StoreHistoryId;
            this.ItemListId = ItemListId;

        }


        //Methods


        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, this store is {this.StoreName} , and it's ID is: {this.Id}");
            return sb.ToString();
        }
    }
}
