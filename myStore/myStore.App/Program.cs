using System;
using myStore.DataInfrastructure;
using myStore.Logic;

namespace myStore.App
{
    class Program
    {
        static void Main()
        {
            string connectionString = "";
            IRepository repo = new SqlRepository(connectionString);

            while (true)
            {
                Console.WriteLine("Compcessories Ordering System.");
                Console.WriteLine("[1]: Place an order.");
                Console.WriteLine("[2]: List locations."); // FUNCTIONING
                Console.WriteLine("[3]: Check customer order history.");
                Console.WriteLine("[4]: Check store order history.");
                Console.WriteLine("[5]: Create a new Customer."); // FUNCTIONING
                Console.WriteLine("[0]: Cancel and close application."); // FUNCTIONING
                string userSelect = Console.ReadLine();

                switch ( userSelect)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("'[1] selected.");

                        //Displaying all customers to select customer to order for
                            IEnumerable<Customer> allCustomers = repo.GetAllCustomers();

                            foreach (Customer customer in allCustomers)
                            {
                                Console.WriteLine(customer.ListCustomer());
                            }

                        Console.WriteLine("Select customer by entering their ID.");

                            string customerIdForOrdering = Console.ReadLine();
                            int customerId = Int32.Parse(customerIdForOrdering);

                        Console.Clear();

                        //Displaying all locations to select location to order from
                            IEnumerable<Location> allLocations = repo.GetAllLocations();

                            foreach (Location newLocation in allLocations)
                            {
                                Console.WriteLine(newLocation.ListLocation());
                            }
                        Console.WriteLine("Select location by entering location ID: ");

                            string locationIdForOrdering = Console.ReadLine();
                            int locationId = Int32.Parse(locationIdForOrdering);

                        Console.Clear();

                        if (locationIdForOrdering == "1")
                        {
                            IEnumerable<Inventory> inventory = repo.GetSanDiegoInventory();
                            foreach (Inventory theinventory in inventory)
                            {
                                Console.WriteLine(theinventory.ListInventory());
                            }
                        }
                        else if (locationIdForOrdering == "2")
                        {
                            IEnumerable<Inventory> inventory = repo.GetPhoenixInventory();
                            foreach (Inventory theinventory in inventory)
                            {
                                Console.WriteLine(theinventory.ListInventory());
                            }
                        }
                        else if (locationIdForOrdering == "3")
                        {
                            IEnumerable<Inventory> inventory = repo.GetSeattleInventory();
                            foreach (Inventory theinventory in inventory)
                            {
                                Console.WriteLine(theinventory.ListInventory());
                            }
                        } 
                        else
                        {
                            Console.WriteLine("Invalid ID, please try again.");
                        }

                        Console.WriteLine("Select product by selecting itemId.");
                        string productIdForOrdering = Console.ReadLine();
                        int productId = Int32.Parse(productIdForOrdering);
                        Console.Clear();
                        Console.WriteLine("Order Submitted");
                        Console.WriteLine("Press Enter to continue, ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2": // FUNCTIONING
                        Console.Clear();
                        Console.WriteLine("[2] selected.");
                        //Location newLocation = new Location(123, "this is adress", "this is city");
                        IEnumerable<Location> allLocations2 = repo.GetAllLocations();

                        foreach (Location newLocation in allLocations2)
                        {
                        Console.WriteLine(newLocation.ListLocation());
                        }

                        Console.WriteLine("Press Enter to continue. ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("[3] selected.");
                        Console.WriteLine("Enter customer ID: ");
                        break;
                    case "4":
                        Console.WriteLine("[4] selected.");
                        Console.WriteLine("Enter store ID:");
                        break;
                    case "5": // FUNCTIONING
                        Console.Clear();
                        Console.WriteLine("[5] selected.");
                        Console.WriteLine("Enter customer's first name.");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter customer's last name.");
                        string lastName = Console.ReadLine();
                        int ID = repo.CreateNewCustomer(new(firstName, lastName));
                        Console.WriteLine("Customer Added.");
                        Console.WriteLine("Press Enter to continue. ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "0": // FUNCTIONING
                        Console.Clear();
                        Console.WriteLine("[0] selected.");
                        Console.WriteLine("Application Closing.");
                        Console.WriteLine("Press Enter to continue. ");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    default: // FUNCTIONING
                        Console.Clear();
                        Console.WriteLine("Unknown input. Returning to menu.");
                        Console.WriteLine("Press Enter to continue. ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }

            // [1] - when selected, should display Customer Table so user can select an ID
            //     - id should be saved, and Location Table should be displayed so user can select Location ID
            //     - location id should be saved, and locationInventory table should be displayed so user can select itemID to purchase
            //     - CHECK if inventory != 0
            //     - should return confirmation with "[itemName] purchased for [customerName] [customerId] from location [locationId] for $[itemPrice]
            //     - should decrement 1-- from [itemId] [qty]
            //     - returns to main menu

            // [3] - when selected, should display Customer Table
            //     - user can select customerId/or name. display orderhistory where customerId = selected customerId
            //     - user can hit enter to continue to main menu

            // [4] - when selected, should display orderhistory Table
            //     - ~~OR~~ dispaly locations Table so user can select storeId and then display orderhistory where storeId = selected storeId

            // **THINGS TO ADD**
            // add a new customer 
            // search customers by name
            // display details of an order
            // customers must have first name and last name

            Console.WriteLine("Hello Again!");
        }
    }
}
