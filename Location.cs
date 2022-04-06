namespace StoreApplication
{
   public static class Location 
    {
            public static Order[] orders;
            public static string? enteredID = " ";
            public static void GetData()
           {
            //read from the text file
            using(var reader = new StreamReader("CustomerRecords.txt"))
            {
                var index = 0;
                orders = new Order[5];
                while (!reader.EndOfStream)
                {
                  //get the line from the text file into an array 
                  var Fullline = reader.ReadLine();
                  Console.WriteLine(Fullline);
                  var line = Fullline.Split('\t');
                  var date = line[0];
                  var orderID = line[1];
                  var firstname = line[2];
                  var lastname = line[3];
                  var phone = line[4];
                  var product = line[5];
                  var location = line[6];
                  var amountspent = line[7];
                  orders[index] = new Order(date, orderID, firstname, lastname, phone, product, location, amountspent);
                  index ++;
                }            
            }
          }

          public static int GetID()
          {
             
              do 
              {
                  var orderindex = 0;
                  Console.WriteLine("\nSearch Customers by OrderID");
                  Console.Write("\nPlease enter order ID : ");
                  enteredID = Console.ReadLine();
                  foreach(var orderID in orders)
                  {
                      if(orderID.OrderID == enteredID)
                      {
                          return orderindex;
                      }
                      else{
                          orderindex++;
                          }
                   }
                   Console.Write("ID does not exist");
              } while (true);
          }  
        
        //get user input 
        public static string UserChoice()
        {
            var userChoice = Console.ReadLine();
            while(userChoice != "1" && userChoice != "2" && userChoice != "3")
            {
                Console.WriteLine("Wrong Entry.Try again");
                DisplayMenu();
                userChoice = Console.ReadLine();
            }
            return userChoice ;
        }
        //display Menu
        public static void DisplayMenu()
        {
           Console.WriteLine("  1.Display Order details by OrderID");
           Console.WriteLine("  2.Exit ");
           Console.Write("  \n\nPlease enter your choice: ");
        }
        
       
    }
}