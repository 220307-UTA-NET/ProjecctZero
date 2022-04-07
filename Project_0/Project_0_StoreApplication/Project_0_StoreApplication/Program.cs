//Diego's Project 0: Store Application
using StoreApplication.Logic;
using StoreApplication.DataInfrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace StoreApplication.App
{
    class Program
    {

        static void Main(string[] args)
        {

            
            Console.WriteLine("Welcome to the Store!");
            Console.WriteLine("_____________________________");
            MainMenu();

            
        }

        /// summary;
        ///  Creating Necessary Methods.
        /// summary
        /// 
        static void MainMenu()
        {
            
                Console.WriteLine("MainMenu:");
                Console.WriteLine("Enter a number");
                Console.WriteLine("[0] - Exit Application");
                Console.WriteLine("[1] - Place an order");
                Console.WriteLine("[2] - Add new customer");
                Console.WriteLine("[3] - Database Menu");

                int? input = int.Parse(Console.ReadLine());
                switch(input)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Application Closed");
                        break;
                    case 1:
                        Console.WriteLine("__________Place an Order__________");
                        //PlaceOrderMethod():Should give user ability to add an order and it's details to the database
                        PlaceOrder();
                        return;
                    case 2:
                        Console.WriteLine("__________Add New Customer__________");
                        //AddNewCustomerMethod():Should give user the ability to add a new customer and their details to the database
                        AddCustomer();
                        return;
                    case 3:
                        Console.WriteLine("__________Database Menu__________");
                        //DatabaseMehod():Should give user the ability to search and make changes to database
                        DatabaseMenu();
                        return;
                


                }
            
            
           
        }
        
        static void PlaceOrder()
        {
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial " + "Catalog=Diego_StoreApp;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;" + "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //CONNECTION STRING GOES HERE!!!!!
            IRepository reposito = new SqlRepository(connectionString);

            Console.WriteLine("Create Order");
            Orders NewOrder = new Orders();
            Console.WriteLine("Enter Product");
            string product = Console.ReadLine();
            NewOrder.SetProduct(product);
            Console.WriteLine("Amount to Purchase");
            int quantity = int.Parse(Console.ReadLine());
            NewOrder.SetQuantity(quantity);
            Console.WriteLine("Store Where Product is Available");
            string dStore = Console.ReadLine();
            NewOrder.SetSL(dStore);
            Console.WriteLine("Name of Customer Ordering");
            string customerName = Console.ReadLine();
            NewOrder.SetCustomer(customerName);
            NewOrder = reposito.CreateNewOrder(product, quantity, customerName,dStore);
            Console.WriteLine("ORder was Created");
        }

        static void AddCustomer()
        {
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial " + "Catalog=Diego_StoreApp;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;" + "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //CONNECTION STRING GOES HERE!!!!!
            IRepository reposit = new SqlRepository(connectionString);

            Console.WriteLine("Adding new customer");
            Customer NewCustomer = new Customer();//reposit.CreateNewCustomer(firstName, lastName, dStore);
            Console.WriteLine("Customers First Name?");
            string firstName = Console.ReadLine();
            NewCustomer.SetFName(firstName);
            Console.WriteLine("Customers Last Name?");
            string lastName = Console.ReadLine();
            NewCustomer.SetLName(lastName);
            Console.WriteLine("Customers Defualt Store?");
            string dStore = Console.ReadLine();
            NewCustomer.SetdefualtSL(dStore);
            NewCustomer = reposit.CreateNewCustomer(firstName, lastName, dStore);
            Console.WriteLine("New Customer was Added");
            //Console.WriteLine(NewCustomer.Introduce());
        }

        static void DatabaseMenu()
        {
            Console.WriteLine("Enter a number");
            Console.WriteLine("[0] - Search Customers");
            Console.WriteLine("[1] - Search Orders");
            Console.WriteLine("[2] - Search Stores");
            string connectionString = "Server=tcp:diego97.database.windows.net,1433;Initial " + "Catalog=Diego_StoreApp;Persist Security Info=False;User ID=Diegod15;Password=Sigma25036!;" + "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; //CONNECTION STRING GOES HERE!!!!!
            
            
                int? input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 0:

                        Console.WriteLine("Searched Customers");
                        IRepository repo = new SqlRepository(connectionString);
                        Console.WriteLine("Connected to Store Database...");
                        IEnumerable<Customer> customers = repo.GetAllCustomers();
                        foreach (Customer customer in customers)
                        {
                            Console.WriteLine(customer.Introduce());
                        }

                        return;
                    case 1:

                        Console.WriteLine("Searched Orders");
                        IRepository repos = new SqlRepository(connectionString);
                        Console.WriteLine("Product Quantity Customer StoreLocation");
                        IEnumerable<Orders> orders = repos.GetAllOrders();
                        foreach (Orders order in orders)
                        {
                            Console.WriteLine(order.Introduce());
                        }

                        return;
                    case 2:
                        Console.WriteLine("Searched Stores");
                        IRepository reposi = new SqlRepository(connectionString);
                        Console.WriteLine("Product Inventory Quantity StoreLocation");
                        IEnumerable<StoreLocation> stores = reposi.GetAllStores();
                        foreach (StoreLocation store in stores)
                        {
                            Console.WriteLine(store.Introduce());
                        }

                        return;
                }
            


        }
        
    }

    

    
}

