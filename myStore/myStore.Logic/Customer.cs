using System;
using System.Text;

namespace myStore.Logic
{
    public class Customer
    {
        // Fields
        int customerId;
        string firstName;
        string lastName;
        //List<orders>???

        // Constructor
        public Customer() { }

        public Customer(int ID, string firstName, string lastName)
        {
            this.customerId = ID;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public Customer( string firstName, string lastName)
        {
            this.customerId = -1;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        // Methods

        public int GetID()
        { return this.customerId; }

        public string GetFirstName()
        { return this.firstName; }

        public string GetLastName()
        { return this.lastName; }

        public string ListCustomer()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"[Customer_Id]: {this.customerId}      [Name]: {this.lastName}, {this.firstName}");
            return sb.ToString();
        }
    }
}
