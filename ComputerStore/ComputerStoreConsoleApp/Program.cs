

using ComputerStore;
using System.Collections;

    Store s = new Store();
    Console.WriteLine("   \n \n ---------------- Welcom to Computer Store! ---------------- " +
        "\n First, you can add a customer and create some computer inventory. " +
        "\n Then you may add some computers to the shopping cart. " +
        "\n Finally, you may checkout which will give you a total value of the shopping cart. \n");

    int action = ChooseAction();

        while(action != 0)
        {
            Console.WriteLine("You chose " + action);
            action = ChooseAction();
            switch (action)
            {
        
                // Adding a new customer 
                case 1:
           
                    Console.WriteLine("You choose to add a new CUSTOMER to the store. \n");

                    string CustName = "";
                    string CustLastName = "";
                    int NumericValue;

                    Console.WriteLine("What's the Customer First Name?");

                    CustName = Console.ReadLine();

                        while (string.IsNullOrEmpty(CustName))
                        {
                            Console.WriteLine("Name can't be empty! Input the name once again.");
                            CustName = Console.ReadLine();
                        }
                        while (int.TryParse(CustName, out NumericValue))
                        {
                            Console.WriteLine("Name can't be a Numeric Value. \n Input the name once again!");
                            CustName = Console.ReadLine();

                        }
            

                    Console.WriteLine("What's the CUSTOMER last name?");
                    CustLastName = Console.ReadLine();
                        while (string.IsNullOrEmpty(CustLastName))
                        {
                            Console.WriteLine("LastName can't be empty! Input your name once again.");
                            CustLastName = Console.ReadLine();
                        }
                        while (int.TryParse(CustLastName, out NumericValue))
                        {
                            Console.WriteLine("LastName can't be a Numeric Value. \n Input LastName once again!");
                            CustLastName = Console.ReadLine();
                            break;
                        }
            
                    Customer NewCustomer = new Customer(CustName, CustLastName);
                    s.CustomerList.Add(NewCustomer);
                    printCustomerInfo(s);
                    break;


                //Adding a Computer to the inventory 
                case 2:
                    Console.WriteLine("You choose to add a Computer to the inventory. \n");

                    string ComputerMake = "";
                    string? ComputerGeneration = "";
                    string? ComputerType = "";
                    decimal ComputerPrice = 0;
                    ArrayList ComputerCompany = new ArrayList();
                    string[] company = { "Acer", "DELL", "Mac", "Lenovo", "Sonny" };
                    ComputerCompany.Add(company);

                    Console.WriteLine("What's the Computer Model? Ex: Acer, DELL, Mac, Lenovo, Sonny");
                    ComputerMake = Console.ReadLine();
                        while (int.TryParse(ComputerMake, out NumericValue))
                        {
                            Console.WriteLine("Your input is incorrect. Please type your input again!");
                            ComputerMake = Console.ReadLine();

                        }

                    Console.WriteLine("What's the Computer Generation? Ex: Generation 1, Generation 2, Generation 3");
                    ComputerGeneration = Console.ReadLine();

                    Console.WriteLine("What's the Computer Type? Ex: Laptop, Desktop");
                    ComputerType = Console.ReadLine();

                    Console.WriteLine("What's the Computer Price? Ex: $500, $700, $10000" + "$");
                    ComputerPrice = 0;
            
                        while (!decimal.TryParse(Console.ReadLine(), out ComputerPrice))
                        {
                            Console.WriteLine("Please Enter a valid decimal value!");
                            Console.WriteLine("What's the Computer Price? Ex: $500, $700, $10000" + "$"); 

                        }
           

                    Computer NewComputer = new Computer(ComputerMake, ComputerGeneration, ComputerType, ComputerPrice);
                    s.ComputerList.Add(NewComputer);
                    printInventory(s);

                    break;



                    // Adding to the CART
                case 3:
                    Console.WriteLine("You choose to add computer to your Cart.");
                    printInventory(s);
                    Console.WriteLine("Which Item would you like to buy? (Choose a Number)");
           
                        try
                        {
                            int ComputerChosen = int.Parse(Console.ReadLine());

                            s.ShoppingList.Add(s.ComputerList[ComputerChosen]);

                            printShoppingCart(s);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Enter a valid number please!");
                
                    }
           

                    break;


                    // Printing out the total cost
                case 4:
                    printShoppingCart(s);
                    Console.WriteLine("The total cost of your items is: " + s.CheckOut() + "$");

                    break;

                default:

                        break;
            }


        }

        static void printShoppingCart(Store s)
    {
        Console.WriteLine("Computers you have chosen to buy: ");
        for (int i = 0; i < s.ShoppingList.Count; i++)
        {
            Console.WriteLine("Computer #" + i + " " + s.ShoppingList[i]);
        }
    }

    static void printInventory(Store s)
    {
        for(int i = 0; i<s.ComputerList.Count; i++)
        {
            Console.WriteLine("Computer #" + i + " " + s.ComputerList[i]);
        }
    }

    static void printCustomerInfo(Store s)
    {
        foreach (Customer c in s.CustomerList)
        {
            Console.WriteLine(c);
        }
    }

    static int ChooseAction()
    {
        int Choice = 0;
        Console.WriteLine("Choose an action:\n 1_ To Quit press [0] \n 2_ To add a new Customer press [1] \n " +
                            "3_ To add a Computer to the inventory press [2] \n 4_ To add Computer to your Cart press [3] " +
                            "\n 5_ To CheckOut press [4]");

        Console.Write("Please Enter Your Number: ");
        Choice = int.Parse(Console.ReadLine());
        return Choice;
    }




/*Computer c = new Computer();
Computer d = new Computer("MacBook", "7th Generation", "Desktop", 2000);

    Console.WriteLine("Computer c is as follow: " + c.ComputerMake + " " + c.ComputerGeneration + " " + c.ComputerType + " " + c.ComputerPrice);
    Console.WriteLine("Computer d is as follow: " + d.ComputerMake + " " + d.ComputerGeneration + " " + d.ComputerType + " " + d.ComputerPrice);
    
    Store s = new Store();
    
    s.ShoppingList.Add(c);
    s.ShoppingList.Add(d);

    decimal total = s.CheckOut();
    Console.WriteLine("The total value of Store is " + total);

    Console.ReadLine();*/

    

