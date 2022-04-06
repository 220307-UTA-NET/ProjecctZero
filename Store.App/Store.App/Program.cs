using Store.DataInfrastructure;
using Store.Logic;
using System;

namespace Store.App
{
    class Program
    {
        static void Main()
        {
            string db_connect = File.ReadAllText(@"c:\Users\Bung9\Desktop\P0_G\Store.App\Store.App\database_connection.txt");
            Console.WriteLine("Welcome to Antiquity Antiques, guest user! Please select an option to continue:\n");
            while (true)
            {
                Console.WriteLine("Create a new Customer       - [1]");
                Console.WriteLine("Customer Search/History     - [2]");
                Console.WriteLine("Store Stock/History         - [3]");
                Console.WriteLine("Change location             - [4]");
                Console.WriteLine("Place an order              - [5]");
                Console.WriteLine("Quit                        - [6]");
                string lname;
                string fname;
                switch (Console.ReadLine())
                {
                    case "1": //REGISTER NEW CUSTOMER
                        Console.Clear();
                        Console.WriteLine("\nPlease provide the following: ");
                        Console.Write("Your First Name: ");
                        fname = Console.ReadLine();
                        Console.Write("Your Last Name: ");
                        lname = Console.ReadLine();
                        Console.Write("Enter a username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter a Password: ");
                        string password = Console.ReadLine();
                        Console.Write("Your Current City: ");
                        string location = Console.ReadLine();
                        Console.WriteLine("\nPlease wait a moment while we add you to the database... ");
                        IRepository repo = new SQLRepo(db_connect);
                        repo.NewCustomer(fname,lname,username,password,location);
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                        Console.WriteLine("\nYou have been added to our database! Press any key to return to the menu.\n");
                        Console.ReadKey();
                        Console.Clear();
                        break;                   
                    case "2": //SEARCH FOR A CUSTOMER AND THEIR ORDERS
                        Console.Clear();
                        Console.WriteLine("\nThis will allow you to look up a customer and their orders in the database. ");
                        Console.Write("Please enter the first name: ");
                        fname = Console.ReadLine();
                        Console.Write("Please enter the last name: ");
                        lname = Console.ReadLine();

                        IRepository repo2 = new SQLRepo(db_connect);
                        IEnumerable<Customer> customer = repo2.CustomerSearch(fname,lname);  
                        if (customer.GetEnumerator().MoveNext() == false)
                        {
                            Console.WriteLine("\tNo customer exists by that name; press any key to return to the main menu\n");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else //If customer exists...
                        {
                            foreach (Customer customerO in customer)
                            {                               
                                Console.WriteLine("Customer " + customerO.GetFirstName() + " " + customerO.GetLastName() + " was located. This is their order history above (if they have one) ");
                                Console.WriteLine("\nPress any key to return to the main menu...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case "3": //DISPLAY CURRENT ITEMS IN A STORE LOCATION
                        Console.Clear();
                        Console.WriteLine("\nCurrent items/quantity at a particular store location as well as store order history ");
                        Console.WriteLine("Please select the store location you wish to see current inventory for: ");
                        Console.WriteLine("Atlanta  - [1]");
                        Console.WriteLine("New York - [2]");
                        Console.WriteLine("Michigan - [3]");
                        Console.WriteLine("Kansas   - [4]");
                        string location_u = Console.ReadLine();
                        switch(location_u)
                        {
                            case "1":
                                location_u = "Atlanta";
                                break;
                            case "2":
                                location_u = "New York";
                                break;
                            case "3":
                                location_u = "Michigan";
                                break;
                            case "4":
                                location_u = "Kansas";                               
                                break;
                            default:
                                Console.WriteLine("Not a valid store location");
                                break;
                        }
                        IRepository repo11 = new SQLRepo(db_connect);
                        repo11.DisplayStoreInventory(location_u);
                        Console.WriteLine("\nPlease press any key to go back to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4": //CHANGE LOCATION
                        Console.Write("Enter your first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter your last name: ");
                        string lastName = Console.ReadLine();
                        IRepository repo6 = new SQLRepo(db_connect);
                        repo6.ChangeLocation(firstName, lastName);                    
                        Console.WriteLine("Please press any key to go back to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5": //PLACE AN ORDER
                        Console.WriteLine("This will allow you to place an order at a store location if you are registered: ");
                        Console.Write("Please enter your first name: ");
                        fname = Console.ReadLine();
                        Console.Write("Please enter your last name: ");
                        lname = Console.ReadLine();
                        Console.WriteLine("");
                        IRepository repo4 = new SQLRepo(db_connect);
                        repo4.NewOrder(fname, lname);
                        Console.WriteLine("Please press any key to go back to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.WriteLine("Thanks for using the Store App!. Now Closing....");
                        return;
                    default:
                        Console.WriteLine("\nNot valid input");
                        break;
                }
            }
        }
    }
}