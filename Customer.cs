using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApplication
{   
// Base Class 
    public class Customer
    { 
       public Customer(string firstname,string lastname,string phone)
               {
                    FirstName = firstname;
                    LastName = lastname;
                    PhoneNumber = phone;
               }
        //Fields
      public string FirstName {get; set;}
      public string LastName {get; set;}
      public string PhoneNumber {get; set;}
         
        //Constructor
        
        //Methods    
        
    }
}

