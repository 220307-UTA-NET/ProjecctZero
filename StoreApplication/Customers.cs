using System;

namespace StoreApplication
{
    class Customers: Customer
    {
      
       List<Customer> customerList = new List<Customer>(); //new List<Customer>();
        
        public void addCustomer()
        {   
            Console.WriteLine("Enter customer number ");
           string? fName="",lName="";
           int id=0;
           id=int.Parse(Console.ReadLine());
           fName = Console.ReadLine();
           lName = Console.ReadLine();
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
                Console.WriteLine(item.getId()+" "+item.getFirstName()+' '+item.getLastName());
        
            }
         }
    }
}
         
       

    

