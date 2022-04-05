using System;

namespace StoreApplication
{
    class Customers: Customer
    {
      
       List<Customer> customerList = new List<Customer>();
        public void select()
        {
           Console.WriteLine("Select below\n 1 - Add customer\n 2 -Search customer\n 3 - Display all ");
           int input = int.Parse(Console.ReadLine()); 
           
        }
         public void AddCustomer()
             {    
                  Console.WriteLine("Enter customer inforamtion ");
                  int id = int.Parse(Console.ReadLine());
                  string fName = Console.ReadLine();
                  string lName = Console.ReadLine();
                  
                  this.setId(id);
                  this.setfirstName(fName);
                  this.setLastName(lName);
                  
                  Customer customer = new Customer(id,fName, lName);
                  this.customerList.Add(customer);
             }
            public void DisplayCustomers()
            {
                Console.WriteLine("ID " + "First Name " + "Last Name");

                foreach(Customer item in this.customerList)
                {
                Console.WriteLine(item.getId()+" "+item.getFirstName()+" " +item.getLastName());
          
                 }
            }
         public void DeletCustomer()

        {
            
            Console.WriteLine("Enter the First");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter last name");
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
        
    }  
}
   

     
    
       

    

