using System;

namespace StoreApplication1

{
    class Orders: Order
    {
      List<Order> orderList = new List<Order>();

       public void AddOrder()
       {
           //Console.WriteLine("Enter order information ");
       while(true) 
         {
            try 
                {
                    
                    Console.WriteLine("Enter order Id ");
                    int orderId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter customerID ");
                    int customerId   =int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter locationID3 ");
                    int locationId = int.Parse(Console.ReadLine());
            
                             break;
                }
            catch
                 {
                      Console.WriteLine("Invalid entry");
                 }

            
          
         }
                   this.setOrderId( orderId );
                   this.setCustomerId(customerId);
                   this.setLocationId(locationId);
                   this.setDateTime(Date);

                Order order = new Order(orderId, customerId,locationId, Date);
                this.orderList.Add(order);
            

         }
        
         public void DisplayOrders()
            {
                Console.WriteLine("Oi " + " CID" + " StoreID" +" " +  "order date");

                foreach(Order item in this.orderList)
                {
                Console.WriteLine(item.getOrderId()+"   "+ getCustomerId()+ "     "  +item.getLocationId()+"     " +item.getDate());
                 Console.WriteLine("______________________________________________");
          
                 }
            }

       
            
         
          
       

        


       
       
    }
 }
 