using System;
using EternalFlowStore.DataInfrastructure;
using EternalFlowStore.Logic;


namespace EternalFlowStore.APP
{

    class Program
    {

        static void Main()
        {
            string connectionString = File.ReadAllText(@"C:\Users\cloudmaster\Revature\ConnectionStrings\RevatureProjectsConnectionString.txt");
            IRepository repo = new SqlRepository(connectionString);

            
            // The program starts here...
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("****** Welcome to EternalFlow Online Crypto Store! *******");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Where You'll Experience an Eternal Flow of Crypto Uptopia!");


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPlease PRESS ENTER to continue. Thank you!");
            Console.ReadLine();
            Console.Clear();

            while (true)
            {

                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[1]: Create an Account");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[2]: Sign-In");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n[3]: Change Store Location");

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n[4]: Search Inventory");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n[5]: My Order");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[6]: Admin Only");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n[0]: Exit");
             

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("What's your first name?");
                        string firstName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat's your last name?");
                        string lastName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat's your address?");
                        string address = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat city do you live in?");
                        string city = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat State/Province/Area?");
                        string stateProvinceArea = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat country do you reside in?");
                        string country = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat's your phone number?");
                        string phoneNumber = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nWhat's your email?");
                        string email = Console.ReadLine();

                        //declaring an object Customers and pullling data from SQL
                        Customers newCustomer = new Customers(firstName, lastName, address, city, stateProvinceArea, country, phoneNumber, email);
                        repo.NewCustomer(newCustomer);

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nTHANK YOU FOR YOUR INPUT. YOUR ACCOUNT HAS BEEN CREATED!");
                        Console.ReadLine();

                        Console.WriteLine("Press ENTER to return to the main menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nWhat's your first name?");
                        string firstName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nWhat's your last name?");
                        Console.ReadLine();
                        string lastName = Console.ReadLine();

                        Customers customerVerification = new Customers(firstName, lastName);
                        repo.CustomerVerification(customerVerification);

                        Console.WriteLine("\n NICE WORK! HAVE FUN SHOPPING!");
                        Console.WriteLine("\nPlease PRESS ENTER to continue. Thank you!");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nPlease choose a location.");

                        Console.WriteLine("\n[1]*Los Angeles*");

                        Console.WriteLine("\n[2]*Seoul*");

                        Console.WriteLine("\n[3]*Singapore*");

                        Console.WriteLine("\n[4]*London*");

                        Console.WriteLine("\n[5]*Paris*");

                        Console.WriteLine("\n[6]*San Salvador*");

                        Console.WriteLine("\n Nice Work!");
                        Console.WriteLine("\nPlease PRESS ENTER to continue. Thank you!");
                        Console.ReadLine();
                        Console.Clear();
                        break;


                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nWelcome to our Inventory!.");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nYour EternalFlow Order");
                        Console.ReadLine();
                        break;

                    case "6":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nADMIN ONLY PAGE");
                        Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nWhat's your first name?");
                        Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nWhat's your last name?");
                        Console.ReadLine();
                        break;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nWhat's your password?");
                        Console.ReadLine();
                        break;

                    case "0":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Thank you for shopping with us! We hope to see you again!");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please try again.");
                        break;

                }
            }
        }

    }
}



