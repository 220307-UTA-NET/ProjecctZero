using System;
using Store.DataInfrastructure;
using Store.Logic;

namespace Store.App
{
    class Program
    {
        static void Main ()
        {
            string connectionString = File.ReadAllText(@"C:\Revature\Store\connectionCred.txt");
            IRepository repo = new SqlRepository(connectionString);
            Console.WriteLine("Hello and welcome to Tuck's Sword and Motorcycle Emporium Order Management Tool"+
                ".\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            while (true)
            {
                
                Console.WriteLine("What would you like to do?\nYour options are:\n1) Get all customer informatio"+
                    "n\n2) Get all order information\n3) Create new customer\n4) Place an order\n5) Get a Custom"+
                    "er ID# using their name\n6) Find all orders for a location\n7) Find all orders for a custome"+
                    "r\n8) Find a complete customer entry from their name\n9) Display the details of a specific o"+
                    "rder\n0) Quit");
                string? capOpt = Console.ReadLine();
                int? newOpt;
                try
                {
                    newOpt = Convert.ToInt32(capOpt);
                }
                catch (Exception)
                {
                    newOpt = 10;
                }
                if (newOpt == 1)
                {
                    IEnumerable<Customer> customers1 = repo.GatherAllCustomers();                    
                    string customerTable = "[Customer ID] [First Name] [Last Name] [Home Store ID]";
                    foreach (Customer customer in customers1)
                    {
                        customerTable += "\n" + customer.GiveCTable();
                    }
                    Console.WriteLine(customerTable);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (newOpt == 2)
                {
                    IEnumerable<Orders> orders1 = repo.GatherAllOrders();
                    string orderTable = "[OrderLine] [Location ID] [Customer ID] [Order Placed] [Item ID] [Quantity] [Order ID]";
                    foreach (Orders order in orders1)
                    {
                        orderTable += "\n" + order.GiveOTable();
                    }
                    Console.WriteLine(orderTable);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (newOpt == 3)
                {
                    Console.WriteLine("Type in the customer's first name and hit return");
                    string? fName = (Console.ReadLine());
                    Console.WriteLine("Type in the customer's last name and hit return");
                    string? lName = (Console.ReadLine());
                    if (fName == null | lName == null)
                    { throw new Exception("Null inputs, try again."); }
                    else
                    {
                        string tmpName = fName + " " + lName;
                        repo.CreateNewCustomer(fName, lName);
                        Console.WriteLine("Customer " + tmpName + " has been created.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else if (newOpt == 4)
                {
                    Console.WriteLine("Enter Location ID");
                    int locationID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Customer ID");
                    int customerID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Item ID");
                    int itemID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Quantity ID");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Order ID");
                    int orderID = Convert.ToInt32(Console.ReadLine());
                    repo.CreateNewOrder(locationID, customerID, itemID, quantity, orderID);
                    Console.WriteLine("New Order Line has been created.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (newOpt == 5)
                {
                    Console.WriteLine("Enter customer's first name");
                    string? fName = Console.ReadLine();
                    Console.WriteLine("Enter customer's last name");
                    string? lName = Console.ReadLine();
                    if (fName == null | lName == null)
                    { throw new Exception("Null inputs, try again."); }
                    else
                    {
                        int custID = repo.GetCustomerID(fName, lName);
                        Console.WriteLine($"This customer's ID number is {custID}.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else if (newOpt == 6)
                {
                    Console.WriteLine("Which location ID would you like to query?");
                    int locationID = Convert.ToInt32(Console.ReadLine());
                    IEnumerable<Orders> orders1 = repo.GatherLocOrders(locationID);
                    string orderTable = "[OrderLine] [Location ID] [Customer ID] [Order Placed] [Item ID] [Quantity] [Order ID]";
                    foreach (Orders order in orders1)
                    {
                        orderTable += "\n" + order.GiveOTable();
                    }
                    Console.WriteLine(orderTable);
                    Console.ReadKey();
                    Console.Clear();                
                }
                else if (newOpt == 7)
                {
                    Console.WriteLine("Which Customer ID would you like to query?");
                    int custID = Convert.ToInt32(Console.ReadLine());
                    IEnumerable<Orders> orders1 = repo.GatherCustOrders(custID);
                    string orderTable = "[OrderLine] [Location ID] [Customer ID] [Order Placed] [Item ID] [Quantity] [Order ID]";
                    foreach (Orders order in orders1)
                    {
                        orderTable += "\n" + order.GiveOTable();
                    }
                    Console.WriteLine(orderTable);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (newOpt == 8)
                {
                    Console.WriteLine("Enter customer's first name");
                    string? fName = Console.ReadLine();
                    Console.WriteLine("Enter customer's last name");
                    string? lName = Console.ReadLine();
                    if (fName == null | lName == null)
                    { throw new Exception("Null inputs, try again."); }
                    else
                    {
                        IEnumerable<Customer> customers1 = repo.GatherOneCustomer(fName, lName);
                        string customerTable = "[Customer ID] [First Name] [Last Name] [Home Store ID]";
                        foreach (Customer customer in customers1)

                        {
                            customerTable += "\n" + customer.GiveCTable();
                        }
                        Console.WriteLine(customerTable);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else if (newOpt ==9)
                {
                    Console.WriteLine("Enter the order #");
                    int orderNum = Convert.ToInt32(Console.ReadLine());
                    IEnumerable<Orders> orders1 = repo.GatherIdOrders(orderNum);
                    string orderTable = "[OrderLine] [Location ID] [Customer ID] [Order Placed] [Item ID] [Quantity] [Order ID]";
                    foreach (Orders order in orders1)
                    {
                        orderTable += "\n" + order.GiveOTable();
                    }
                    Console.WriteLine(orderTable);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (newOpt == 0)
                {
                    break;
                }                
            }
        }
    }
}
