using System;
using System.Collections.Generic;
using System.IO;

namespace StoreApplication_P0.Logic 
{
    public class CustomerAccount : AccountInfo
    {
        // Fields
        protected int? CustomerID;

        // Constructors
        public CustomerAccount() { }
        public CustomerAccount(int? CustomerID, string username , string password, string firstName, string lastName, string email,  string default_location)
        {
            this.CustomerID = CustomerID;
            this.firstName = firstName;
            this.lastName = lastName;
             //this.DOB = setDOB();
            this.email = email;
            this.username = username;
            this.password = password;
            this.setUserName(username);
            this.setPassword(password);
            this.default_location = default_location;
        }

            //// creating object of CustomerAccount() with name username
            //CustomerAccount new_account = new CustomerAccount( null, usernameInput, passwordInput, firstNameInput, lastNameInput, emailInput, defaultLocation);

            ////Console.WriteLine("The Customer's first and last name is: " + new_account.getfirstName() + " " + new_account.getlastName() );                

        }
    }
