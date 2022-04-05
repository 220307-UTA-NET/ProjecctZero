using System;

namespace StoreApplication
{
    class Program
    {
       static void Main(string[] args)


       {
           //Console.WriteLine("Select below\n 1- Add customer\n 2 -Search customer\n 3- Display all ");
           Customers customer = new Customers();
           Orders order  = new Orders();
           Products  product  =  new Products();
           Locations location = new Locations();

        //    product.AddProduct();
        //    product.dispalyProduct();
        //    
           customer.AddCustomer();
          // customer.DisplayCustomers();
          // customer.DeletCustomer();
          customer.DisplayCustomers();


    //         int input = 999;
        
    //    while(true)
    //    {
    //        Console.WriteLine("Select 0 to exit\n Select below\n 1 - Add customer\n 2 -Search customer\n 3 - Display all ");
    //        try{
    //         input = int.Parse(Console.ReadLine()); 
    //        }

    //        catch (Exception e)
    //        {
    //            Console.WriteLine("Inavalid Entry ");
    //            input = 999;
                
    //         }

           
    //        switch(input)
    //         {
    //             case 0:
    //             Environment.Exit(0);
    //             break;
                
    //            case 1:
    //            customer.AddCustomer();
               
    //             break;

    //            case 2:
    //              customer.DeletCustomer();
    //                 break;
    //             case 3:
               

    //              customer.DisplayCustomers();
    //            break;

    //           default:
    //           Console.WriteLine("Wrong selection");
              
    //           break;
    //     }
    //        } 
            }
    }
}