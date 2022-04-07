using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace  StoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, choice, sum = 0;
            string? input = "";
            string? AOid;
            string? Afirstname, Alastname, Aphonenumber, ALocation ;
            string[] products = new string[25] { "Bread", "Milk", "Soda", "Beef", "Pork", "Coffee", "Beer" , "Chicken","Eggs","Strawberry","Apples","Oranges","Banana","Cucumber",
               "Celery","Curd","Carrots","Beans","Pepper","Onions","Ginger","Garlic","Avacado","Grapes","Tomato"};
            int[] prices = new int[25] { 1, 2, 2, 5, 4, 6, 3, 5, 3, 4, 3, 4, 1, 1, 2, 2, 3, 2, 2, 3, 1, 1, 4, 2, 2 };

            
           Console.WriteLine("Store Application");
           Console.WriteLine("\nPrinting sales records of the Store... ");


           //Create a order class object            
          /* var newOrder = new Order("1", "Anu","Thekkekattil","1234567890","Groceries","Walmart",50);
           //Console.WriteLine(newOrder);
           Order newOrder1 = new("2",  "Rupa","Anu", "126543733", "Accessories", "Walmart",100);
           Order newOrder2 = new("3", "Anil","Villamkandathil","987654321","GardenSupply","Walmart", 200);
           Order newOrder3 = new("4", "Avyukth", "Anil", "12344566", "Toys", "Walmart",25);
           Order newOrder4 = new("5",  "Arnav","Anil", "987654333", "Clothes", "Walmart",20);
           */
           //Calling Record method
          // newOrder.Record();
         //  newOrder1.Record();
         //  newOrder2.Record();
         //  newOrder3.Record();
         //  newOrder4.Record();
          // Order.Record();
         // newOrder.Record1();
        //  newOrder1.Record1();
        //  newOrder2.Record1();
        //  newOrder3.Record1();
        //  newOrder4.Record1();
        do {
                       Location.GetData();
                       var orderIndex = Location.GetID();
                       Location.DisplayMenu();
                       if(Location.UserChoice() == "1")
                       Console.WriteLine(Location.orders[orderIndex].ToString());
                       else 
                       break;  
            }  while (true);

Console.WriteLine("\nCreating an Order................");
Console.WriteLine("\nThis is a list of shop products:");
for(i = 0; i < products.Length; i++)
{
    Console.WriteLine((i+1) + ". " + products[i]);
}
while(!input.ToLower().Equals("p"))
{
    input = Console.ReadLine();
    if(Int32.TryParse(input, out choice))
    {
        choice = choice-1;
        if(choice >= 0 && choice < products.Length)
        {
            Console.WriteLine("Adding " + products[choice] + " to the list.");
            sum += prices[choice];
        }
        else
        {
            Console.WriteLine("Invalid input, please enter a number between 1-7.");
        }
    }
    else if(input.ToLower().Equals("p"))
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid input, please enter a number between 1-7 or P to exit.");
    }
}

Console.WriteLine("The final cost of the products is $" + sum);

Console.WriteLine("Input customer details");
Console.WriteLine("Enter OrderID");
AOid = Console.ReadLine();
Console.WriteLine("Enter First Name");
Afirstname = Console.ReadLine();
Console.WriteLine("Enter Last Name");
Alastname = Console.ReadLine();
Console.WriteLine("Enter PhoneNumber");
Aphonenumber = Console.ReadLine();
Console.WriteLine("Enter Location");
ALocation = Console.ReadLine();
Console.WriteLine("\n Printing Order details............");
Console.WriteLine("OrderID       " +AOid);
Console.WriteLine("FirstName     " +Afirstname);
Console.WriteLine("LastName      " +Alastname);
Console.WriteLine("PhoneNumber   " +Aphonenumber);
Console.WriteLine("Location      " +ALocation);
Console.WriteLine("AmountSpent   " +sum);
DateTime Current = DateTime.Now;
string[] content = {(Current.ToString("F"))  + "\t" + AOid+ "\t" + Afirstname + "\t" + Alastname + "\t" + Aphonenumber + "\t" + ALocation + "\t"  + "\t" + sum};
  
            string path = @".\CustomerRecords2.txt";
           // Console.WriteLine(path);
            if(!File.Exists(path))
            {
                
                //create and write to new file 
                File.WriteAllLines(path, content);
                //File.Copy(path, content);
            }
            else 
            {
                // append the existing file    
             File.AppendAllLines(path, content);
            }
        }     
         
    }
}
