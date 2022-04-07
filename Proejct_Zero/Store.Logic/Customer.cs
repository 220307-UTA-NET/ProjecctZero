using System;
using System.Text;

namespace Store.Logic
{
    public class Customer
    {
        // Fields
        int ID;
        string FirstName, LastName;


        // Constructors
        public Customer() { }
        public Customer(int ID, string FirstName, string LastName)
        {
            this.ID = ID; 
            this.FirstName = FirstName;
            this.LastName = LastName;
        }


        // Methods
        public int GetID()
        {
            return this.ID;
        }
        public string GetFirstName()
        {
            return this.FirstName;
        }
        public string GetLastName()
        {
            return this.LastName;
        }
        public void SetFirstName(string FirstName)
        {
            this.FirstName=FirstName;
        }
        public void SetLastName(string LastName)
        {
            this.LastName=LastName;
        }

        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, my name is {this.FirstName} {this.LastName}, and I am Customer {this.ID}");
            return sb.ToString(); 
        }
    }
}