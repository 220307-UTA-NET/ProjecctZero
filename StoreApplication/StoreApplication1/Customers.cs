using System;

namespace StoreApplication1
{
    internal class Customers: Customer
    {
      
       List<Customer> customerList = new List<Customer>();
        public void select()
        {
          
           int input = int.Parse(Console.ReadLine()); 
           
        }
         public void AddCustomer()
             {    
                 // Console.WriteLine("Enter customer inforamtion ");
                  Console.WriteLine("Enter customer ID");
                  int id = int.Parse(Console.ReadLine());

                  Console.WriteLine("Enter first name");
                  string fName = Console.ReadLine();

                  Console.WriteLine("Enter customer last name\n");
                  string lName = Console.ReadLine();
                  
                  this.setId(id);
                  this.setfirstName(fName);
                  this.setLastName(lName);
                  
                  Customer customer = new Customer(id,fName, lName);
                  this.customerList.Add(customer);
             }
            public void DisplayCustomers()
            {
                Console.WriteLine("ID " + "F Name " + "L Name");

                foreach(Customer item in this.customerList)
                {
                Console.WriteLine(item.getId()+"     "+item.getFirstName()+"  " +item.getLastName());
                   Console.WriteLine("_______________________________________________");
                 }
            }
            
         public void DeletCustomer()

         {
            
            // Console.WriteLine("Enter the First");
             string firstName = Console.ReadLine();

            // Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();

            int counter = 0;

            foreach(Customer item in this.customerList)
                {
                    if (firstName == item.getFirstName() && lastName == item.getLastName())
                    {
                        this.customerList.RemoveAt(counter);
                    }
                        counter++;
                }       
              
         }
         
        //      
            
    }
        
}  

   

     
    
       

    

