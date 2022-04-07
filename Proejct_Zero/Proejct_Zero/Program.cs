using System;
using Store.Logic;
using Store.DataInfrastructure;

namespace Store.App
{
    class Program
    {
        static void Main(string[] args)
        {

            bool showMenu = true;
            while( showMenu )
            {
                showMenu = MainMenu();
            }

        }

        private static bool MainMenu()
        {
            string connectionString = "Server=tcp:tuann1821-net.database.windows.net,1433;Initial Catalog=wk-3-MyDatabase;Persist Security Info=False;User ID=tuann1821;Password= Dragon123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            IRepository repo = new StoreRepository(connectionString);

            Console.WriteLine("Welcome to Tuan's Toy Shop!");
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("[1] - Show All Customer");
            Console.WriteLine("[2] - New Customer");
            Console.WriteLine("[3] - Search Customer");
            Console.WriteLine("[4] - Order");
            Console.WriteLine("[5] - Location");
            Console.WriteLine("[6] - Exit");

            int options = int.Parse(Console.ReadLine());

            switch (options)
            {
                case 1:
                    IEnumerable<Customer> customers = repo.GetAllCustomers();

                    foreach (Customer customer in customers)
                    {
                        Console.WriteLine(customer.Introduce());
                    }
                    return true;

                case 2:
                    Customer NewCustomer = repo.CreateNewCustomer(Console.ReadLine(), Console.ReadLine());
                    Console.WriteLine(NewCustomer.Introduce());
                    break;

                case 3:
                    Console.WriteLine("Which customer would you like to search?");
                    Console.WriteLine(repo.GetCustomer(int.Parse(Console.ReadLine())));
                    return true;
                case 6:
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    return false;
            }

            return true;
        }

        private static void NewCustomer()
        {
            throw new NotImplementedException();
        }
    }
}