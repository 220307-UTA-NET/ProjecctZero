using System;

namespace StoreApplication

{
    class Orders: Order
    {
      List<Order> orderList = new List<Order>();

       public void AddOrder()
       {
           Console.WriteLine("Enter order information ");

            int orderId = int.Parse(Console.ReadLine());
            int customerId   =int.Parse(Console.ReadLine());
            int locationId = int.Parse(Console.ReadLine());
            this.setOrderId(orderId );
            this.setCustomerId(customerId);
            this.setLocationId(locationId);
            this.setDateTime(Date);

            Order order = new Order(orderId, customerId,locationId, Date);
            this.orderList.Add(order);
           

        Console.WriteLine("--------------------------------------");
        Console.WriteLine("orderID " + "CustomerID " + "Location");

            //convert int id = int.Parse(Console.ReadLine());
      //  orderList.Add(3 +  "      Toyota " +     "    0987   " + "  "  );
           
           
           // foreach(String item in orderList)
            // {
            //     Console.WriteLine( item);
            // }
       }
    }
 }
 