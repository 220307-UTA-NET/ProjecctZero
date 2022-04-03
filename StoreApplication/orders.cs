using System;

namespace StoreApplication

{
    class Orders: Order
    {
     //  var List<string> orderList;

       public void AddOrder()
       {
        List<string> customerList = new List<string>();
            Console.WriteLine("orderID " + "ProductName " + "prouctID");
            customerList.Add(1    + "      Shose " +     "    0987   " + "  "  );
           
           
            foreach(String item in customerList)
            {
                Console.WriteLine( item);
            }
       }
    }
 }
 