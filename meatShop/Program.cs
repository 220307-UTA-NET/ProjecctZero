using System;
using System.Collections.Generic;
using System.Globalization;
using meatShop.Logic;
using System.IO;
using meatShop.DataInfrastructure;

namespace meatShop
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ///<summary>
                ///testing for the various classes created
                ///</summary>
                string connectionString = //CONNECTION STRING GOES HERE!!!!!
                string dope = File.ReadAllText(@"/Users/francis/revature/meatShop/meatShop/AzureConn.txt");

                IRepository repo = new SqlRepository(connectionString);

                Console.WriteLine("Welcome to the Butcher's Terminal!");
                Console.WriteLine("Enter the number for the menu option of your choice: ");
                Console.WriteLine("[1] - Add A Customer");
                Console.WriteLine("[2] - Find a Customer");
                Console.WriteLine("[3] - List all Customers");
                Console.WriteLine("[4] - List all Stores");
                Console.WriteLine("[5] - Add a new Order");
                Console.WriteLine("[6] - Show all Orders in all the stores");
                Console.WriteLine("[0] - Exit");

                int menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 0:
                        Console.WriteLine("Press Enter to continue exiting.");
                        Console.ReadLine();
                        Console.Clear();
                        return;

                    case 1:
                        Console.WriteLine("What is the First Name of the Customer");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("What is the Last Name of the Customer?");
                        string LastName = Console.ReadLine();
                        Console.WriteLine("What is their HistoryId? Enter zero if new.");
                        int HistoryId = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is the name of the Store? The Butchery, Ribs and More, Hocks of Ham");
                        string PrimaryStore = Console.ReadLine();

                        Customer NewCustomer = repo.CreateNewCustomer(FirstName, LastName, HistoryId, PrimaryStore);
                        Console.WriteLine(NewCustomer.Introduce());
                        break;

                    case 2:
                        Console.WriteLine("What is the Id number of the Customer?");
                        int Id = int.Parse(Console.ReadLine());
                        
                        CustomerInfo myCustomer = new CustomerInfo(repo);
                        Customer tempCustomer = myCustomer.GetCustomer(Id);

                        Console.WriteLine(tempCustomer.Introduce());

                        break;

                    case 3:
                        ///<params>list all customers</params>
                        IEnumerable<Customer> customers = repo.GetAllCustomers();

                        foreach (Customer customer in customers)
                        {
                            Console.WriteLine(customer.Introduce());
                        }
                        break;

                    case 4:
                        //list all stores
                        CustomerInfo Allstores = new CustomerInfo(repo);
                        Console.WriteLine(Allstores.IntroduceAllStores());
                        break;

                    case 5:
                        //Store temp2 = new Store(13, "Quality Meats", "HedgeHog, Nevada", 34,31);
                        //Console.WriteLine(temp2.Introduce());

                        //Order temp2 = new Order(1 ,13, 3, 1,"Gizzard", 2, 1);
                        //Console.WriteLine(temp2.Introduce());
                        //Product temp4 = new Product(2, "Banna Steak", "BurningSteaksauce", 5.66, 43, 4);
                        //Console.WriteLine(temp4.Introduce());
                        //ItemList temp7 = new ItemList(3, 3, 4, 5, 6, 5);
                        //Console.WriteLine(temp7.Introduce());
                        var date1 = DateTime.Now;
                        Console.WriteLine(date1);
                        string date2 = date1.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        Console.WriteLine("What is this order number? Use previous number to add to order.");
                        int OrderId = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is the Store Id number? 1 for The Butchery, 2 for Ribs and More, 3 for Hocks of Ham");
                        int StoreId = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is your Customer ID?");
                        int CustomerId = int.Parse(Console.ReadLine());
                        Console.WriteLine("what are you going to order? T-bone, Whole Chicken or Skirt");
                        string OrderPlaced = (Console.ReadLine());
                        Console.WriteLine("How many do you want?");
                        int ProductAmount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Choose a shopping cart number");
                        int ItemListId = int.Parse(Console.ReadLine());

                        Order neworder = repo.CreateNewOrder(OrderId, StoreId, CustomerId, date2 ,OrderPlaced, 2, 5);
                        Console.WriteLine(neworder.Introduce());
                        break;
                    case 6:
                        IEnumerable<UltimateWarrior> orders = repo.GetAllOrders();
                        
                        foreach (UltimateWarrior order in orders)
                        {
                            Console.WriteLine(order.Introduce());
                        }
                        break;

                }

               
               ///<params>
               ///this is the joining third table
               ///</params>
                //Customer_Store temp3 = new Customer_Store(133, 54, 23);
                //Console.WriteLine(temp3.Introduce());

             

            

            }
        }
    }
}
