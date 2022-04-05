using System;

namespace StoreApplication{

    class Order: Product
    {
        public int orderId;// {get; set;}
        public int customerId;// {get; set;}
        public int locationId ;//{get; set;}
        public DateTime Date; //{get; set;}
        public List<String> cart = new List<string>();

        public Order()
        {

        }

        public Order(int OrderID, int CustomerId, int LocationId, DateTime Date)
        {
            this.orderId = OrderID;
            this.customerId = CustomerId;
            this.locationId = LocationId;
            this.Date = Date;

            
        }
        public int getOrderId()
        {
          return this.orderId;
            
        }
        public int getCustomerId()
        {
          return this.customerId;
            
        }
        public int getLocationId()
        {
          return this.locationId;
            
        }
        public  DateTime getDate()
        {
            return this.Date; 
        }
        public void setOrderId(int OrderId)
        {
          this.orderId = OrderId;
            
        }
         public void setCustomerId(int customerId)
        {
          this.customerId = customerId;
            
        }
         public void setLocationId(int LocationId)
        {
          this.locationId= LocationId;
            
        }
         public void setDateTime( DateTime Date)
        {
          this.Date = Date;
            
        }
        
        public void addProductToCart()
        {
            Console.WriteLine("Enter product inforamtion ");
                 
        }
        public void  orderProduct()
        {

        }
        public void cancleProduct()
        {

        }
 }
}