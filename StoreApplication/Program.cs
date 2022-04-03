using System;

namespace StoreApplication
{
    class Program
    {
       static void Main(string[] args)


       {
           Customers customer = new Customers();
           Orders order  = new Orders();
           Products  product  =  new Products();

           

        
            customer.addCustomer();
            customer.addCustomer();
            customer.addCustomer();
            customer.DisplayCustomers();      

       }
        

        
    }
}