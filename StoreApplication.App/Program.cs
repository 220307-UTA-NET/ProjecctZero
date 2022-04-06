using System;
using StoreApplication.Infrastructure;
//using System.FormatException;

namespace StoreApplication.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //string connectionString = File.ReadAllText("dkeita-myserver.database.windows.net");

            string connectString = "Server=tcp:dkeita-myserver.database.windows.net,1433;Initial Catalog=Dkeita-MyDatabase;Persist Security Info=False;User ID=logindkeita;Password=Bocanegra07%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            InterfaceRepo repo = new SqlRepository(connectString);

            Manager manager = new Manager(repo);

            //manager.displayAllProduct();


            // Based on phone number, we will know it is a new customer or an existing customer
            Console.WriteLine("WELCOME TO TECHNOLOGY REVOLUTION");

            Console.WriteLine("\nThe list of the products available at the store locations\n");
            manager.displayAllProduct();

            Console.WriteLine("\npress [1] to place orders to store for a customer");
            Console.WriteLine("press [2] to search customers by name");
            Console.WriteLine("press [3] to display details of an order");
            Console.WriteLine("press [4] to display all order history of a store location");
            Console.WriteLine("press [5] to display all order history of a customer\n");
            Console.Write("Enter a number =>  ");
            string str = Console.ReadLine();
            int opt = int.Parse(str);
            // Declaring an array of integers
            int[] opts = { 1, 2, 3, 4, 5 };
            //string[] letters = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool isIn = true;
            
            // Input validation
            while (!Array.Exists(opts, x => x == opt))
            {
                Console.Write("Input error. Enter a valid input or press [enter] to exit => ");
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    isIn = false;
                    break;
                }
                opt = int.Parse(str);
            }



            // Switch statement
            switch (opt)
            {
                case 1:
                    // 1.place orders to store locations for customers
                    Console.Write("\nEnter your phone number to place an order. => ");
                    string phoneNumber = Console.ReadLine();

                    while (!allDigits(phoneNumber))
                    {
                        Console.Write("\nInput error. Enter your phone number to place an order. => ");
                        phoneNumber = Console.ReadLine();
                    }

                    // Input validation for phone number

                    // if the phone number entered is in the database, 
                    //    place the customer order
                    manager.placeOrder();

                    // otherwise,
                    //   => add the new customer in the database, then place the order
                    manager.addCustomer(phoneNumber);
                    manager.placeOrder();
                    break;

                case 2:
                    manager.searchCustomer();
                    break;

                case 3:
                    // display order details
                    manager.displayOrder();
                    break;

                case 4:
                    // display all order history of a store location
                    manager.displayOrder("order history of a", "store", "location");
                    break;

                case 5:
                    manager.displayOrder("order history of a", "customer");
                    break;
            }
        }

        static bool allDigits(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
