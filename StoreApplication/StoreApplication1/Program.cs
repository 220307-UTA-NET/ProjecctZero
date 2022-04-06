using System;

namespace StoreApplication1
{
    class Program
    {
         static void Menu()
             {
                 Console.WriteLine("Select 0 to exit ");
                 Console.WriteLine(" 1 - Add customer\n 2 - DeletCustomer ");
                 Console.WriteLine(" 3 - Add product\n 4 - Order product ");
                 Console.WriteLine(" 5 - Remove order");
             }
    
       static void Main(string[] args)

         {
           //Console.WriteLine("Select below\n 1- Add customer\n 2 -Search customer\n 3- Display all ");
           Customers customer = new Customers();
           Orders order  = new Orders();
           Products  product  =  new Products();
           Locations location = new Locations();


            // order.AddOrder();
            // order.DisplayOrders();

            int input = 999;
            
        
       while(true)
       {
          
           Menu();
           try{
            input = int.Parse(Console.ReadLine()); 
           }

           catch (Exception e)
           {
               Console.WriteLine("Inavalid Entry ");
               input = 999;
                
            }

           switch(input)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                
                case 1:
                        customer.AddCustomer();
                        customer.DisplayCustomers();
                        break;

                case 2:
                    customer.AddCustomer();
                    customer.DisplayCustomers();
                    customer.DeletCustomer();
                        break;

                case 3:
                     product.AddProduct();
                     product.dispalyProduct();
                        break;

                case 4:
                    order.AddOrder();
                    order.DisplayOrders();
                         break;
                       break;
                default:
                      Console.WriteLine("Wrong selection");
              
              break;
        }
           } 
        
            }
     }
}