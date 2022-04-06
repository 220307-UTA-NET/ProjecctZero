using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreApplication.Logic
{
    public class Customer
    {
        // Fields
        private int CustomerID;
        private string FirstName;
        private string LastName;
        private string PhoneNumber;
        //private string StreetNumber;
        private string Zipcode;

        public Customer() {
            this.CustomerID = 0;
            this.FirstName = "";
            this.LastName = "";
            this.PhoneNumber = "";
            //this.StreetNumber = "";
            this.Zipcode = "";
        }

        public Customer(int customerID, string firstName, string lastName, string phoneNumber, string zipcode)
        {
            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            //this.StreetNumber = streetNumber;
            this.Zipcode = zipcode;
        }
        public int GetCustomerID() { 
            return this.CustomerID; }
        public string GetFirstName() { return this.FirstName; }

        public string GetLastName() { return this.LastName; }

        public string GetPhoneNumber() { return this.PhoneNumber; }

        //public string GetStreetNumber() { return this.StreetNumber; }

        public string GetZipcode() { return this.Zipcode; }



    }
}