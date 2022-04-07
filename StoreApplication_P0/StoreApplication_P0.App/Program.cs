using System;
using System.Collections.Generic;
using System.IO;
using StoreApplication_P0.Logic;
using StoreApplication_P0.DataInfrastructure;


namespace StoreApplication_P0.App
{
    class Program
    {
        static void Main()
        {
            string connectionString = File.ReadAllText(@"/Revature/ConnectionStrings/Project0.txt");

            Console.Clear();
            Console.WriteLine("Welcome to the Bakery App!");

            while (true)
            {
                Console.WriteLine("Please select from the following: ");
                Console.WriteLine("[1] - Existing Account");
                Console.WriteLine("[2] - Create New Account");

                int home = int.Parse(Console.ReadLine()); // Add Try-Parse here!

                switch (home)
                {
                    case 1:
                        Console.WriteLine("Enter your username: ");
                        string input = Console.ReadLine();

                        //repo.findUsername(input);

                        Console.WriteLine("Enter your password: ");
                        Console.ReadLine();
                        break;
                    case 2:
                        Bakery.CreateAccount();
                        Console.Clear();
                        Console.WriteLine("Thank you for creating an account.");
                        Console.WriteLine("Please press enter to start your order.");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("' " + home + " '  is not a valid option. Please press enter and try again.");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                }
                break;
            }  // End of while loop


            while (true)
            {
                //Order newOrder = new Order();

                Console.WriteLine("~~~~~~   Menu   ~~~~~~");
                Console.WriteLine("Please select from the options below: ");
                Console.WriteLine("\nEnter Items                   Price   Qnt");
                Console.WriteLine(" [1]  Chocolate Cake            $40    - ");
                Console.WriteLine(" [2]  Strawberry Shortcake      $40    -");
                Console.WriteLine(" [3]  Red Velvet                $30    -");
                Console.WriteLine(" [4]  Boston Cream Pie          $50    -");
                Console.WriteLine(" [5]  Tiramisu                  $40    -");

                int selection = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (selection)
                {
                    case 1:

                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem            Price   ");
                        Console.WriteLine("Chocolate Cake    $40      ");
                        Console.Write("\nqnt: ");
                        decimal qnt = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem            Price   Qnt   Total");
                        Console.WriteLine("Chocolate Cake    $40     " + qnt + "      " + qnt * 40);
                        // add method here 
                        //newOrder = new Order("Chocolate Cake", qnt);
                        Console.WriteLine("\nPlease press enter to continue");
                        Console.ReadLine();
                        //return newOrder;
                        break;

                    case 2:
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem                  Price   ");
                        Console.WriteLine("Strawberry Shortcake    $40      ");
                        Console.Write("\nqnt: ");
                        qnt = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem                   Price   Qnt   Total");
                        Console.WriteLine("Strawberry Shortcake     $40     " + qnt + "     " + qnt * 40);
                        //newOrder = new Order("Strawberry Shortcake", qnt);
                        Console.WriteLine("\nPlease press enter to continue");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem          Price ");
                        Console.WriteLine("Red Velvet    $30      ");
                        Console.Write("\nqnt: ");
                        qnt = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem        Price   Qnt   Total");
                        Console.WriteLine("Red Velvet   $30    " + qnt + "      " + qnt * 30);
                        //newOrder = new Order("Red Velvet", qnt);
                        Console.WriteLine("Please press enter to continue");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem             Price  ");
                        Console.WriteLine("Boston Cream Pie    $50      ");
                        Console.Write("\nqnt: ");
                        qnt = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem             Price   Qnt   Total");
                        Console.WriteLine("Boston Cream Pie    $50           " + qnt * 50);
                        //newOrder = new Order("Boston Cream Pie", qnt);
                        Console.WriteLine("Please press enter to continue");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem       Price   ");
                        Console.WriteLine("Tiramisu     $40      ");
                        Console.Write("\nqnt: ");
                        qnt = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Please select a quantity: ");
                        Console.WriteLine("\nItem       Price   Qnt   Total");
                        Console.WriteLine("Tiramisu     $40           " + qnt * 40);

                        //TiramisuOrder = new Order("Tiramisu", qnt);
                        Console.WriteLine("Please press enter to continue");
                        Console.ReadLine();
                        break;
                }

                //newOrder.GetOrderQnty();
                Console.WriteLine("Enter 1 to complete your order, or enter 2 to add more items.");
                int? repeat = int.Parse(Console.ReadLine());
                if (repeat == 1)
                { break; }
            }


        } // End of Main

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //static void Main()
        //{
        //    string connectionString = File.ReadAllText(@"/Revature/ConnectionStrings/Project0.txt"); //CONNECTION STRING GOES HERE!!!!!
        //    IRepository repo = new SqlRepository(connectionString);

        //    Console.Clear();
        //    Console.WriteLine("Welcome to the Bakery App!");

        //    while (true)
        //    {
        //        Console.WriteLine("Please select from the following: ");
        //        Console.WriteLine("[1] - Existing Account");
        //        Console.WriteLine("[2] - Create New Account");

        //        int home = int.Parse(Console.ReadLine()); // Add Try-Parse here!

        //        switch (home)
        //        {
        //            case 1: 
        //                // ExistingAccount();
        //                break;
        //            case 2:
        //                Bakery.CreateAccount();
        //                Console.Clear();
        //                Console.WriteLine("Thank you for creating an account.");
        //                Console.WriteLine("Please press enter to start your order.");
        //                Console.ReadLine();
        //                break;

        //            default:
        //                Console.WriteLine("' " + home + " '  is not a valid option. Please press enter and try again.");
        //                Console.ReadLine();
        //                Console.Clear();
        //                break;
        //        }




        //        break;
        //    }  // End of while loop
        //}       // End of Main 

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //IRepository repo = new SqlRepository(connectionString);







    }
}


