using System;
using System.Collections.Generic;
using System.IO;
using StoreApplication_P0.Logic;
using StoreApplication_P0.DataInfrastructure;
using System.Text;

namespace StoreApplication_P0.App
{
    public class Bakery
    {
        /// ~~~~~~~~~~~~~~~      Taking in New Account Info     ~~~~~~~~~~~~~~~~~~
        public static void CreateAccount()
        {
            string connectionString = File.ReadAllText(@"/Revature/ConnectionStrings/Project0.txt"); //CONNECTION STRING GOES HERE!!!!!
            IRepository repo = new SqlRepository(connectionString);

            Console.Write("\nPlease enter your first name:    ");
            string? firstNameInput = Console.ReadLine(); // maybe put in try-parse

            Console.Write("\nPlease enter you last name:    ");
            string? lastNameInput = Console.ReadLine();

            Console.Write("\nPlease enter your email:    ");
            string? emailInput = Console.ReadLine();

            Console.Write("\nPlease choose a username:    ");  // add method to check against other usernames
            string? usernameInput = Console.ReadLine();

            Console.Write("\nPlease choose a password:    ");  // need to add second input for verification
            string? passwordInput = Console.ReadLine();

            Console.WriteLine("\nPlease select a default store location: ");

            string defaultLocation = SelectDefaultStore();

            Console.WriteLine("You're default store location is set to " + defaultLocation);
            Console.WriteLine("\nPlease press enter to continue.");
            Console.ReadLine();
            CustomerAccount new_account = repo.CreateNewCustomerAccount(usernameInput, passwordInput, firstNameInput, lastNameInput, emailInput, defaultLocation);


            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //~~~~~~~~~~~~~~~~~~~   Choosing Store Location    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            static string SelectDefaultStore()
            {
                while (true)
                {
                    Console.WriteLine("[1] Springfield_VA");
                    Console.WriteLine("[2] Washington_DC");
                    Console.WriteLine("[3] Charlottesvilles_VA");

                    int selection = int.Parse(Console.ReadLine());
                    string defaultStore;

                    if (selection == 1)
                    {
                        return defaultStore = "Springfield_VA";
                    }
                    else if (selection == 2)
                    {
                        return defaultStore = "Washington_DC";
                    }
                    else if (selection == 3)
                    {
                        return defaultStore = "Charlottesvilles_VA";
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please press enter and try again.");
                        Console.ReadLine();
                    }
                }
            }

        }

        /*//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //              `*Needs more work - put into repo*
        //~~~~~~~~~~~~~~~~~~~   Returns list of usernames ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public string ListOfUsernames(string expectedUsername)
        {
            string connectionString = File.ReadAllText(@"/Revature/ConnectionStrings/Project0.txt");
            IRepository repo = new SqlRepository(connectionString);
            var allAccounts = repo.GetAllCustomerAccounts();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (CustomerAccount account in allAccounts)
            {
                
                stringBuilder.AppendLine(account.getUsername());
            }
            return stringBuilder.ToString();
        }
        //IEnumerable<CustomerAccount> listOfAcct = repo.GetAllCustomerAccounts();
        //foreach (CustomerAccount eachAcct in listOfAccts)

        *//*string eachUsername = account.getUsername();
                if (eachUsername == expectedUsername)
                {return expectedUsername;}
                else
                {return "";}*/

    }
}


//~~~~~~~~~~~~~
