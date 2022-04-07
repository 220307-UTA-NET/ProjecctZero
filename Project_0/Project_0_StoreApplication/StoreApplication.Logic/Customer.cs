using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplication.Logic
{
    public class Customer
    {
        //Fields
        private int customerID;
        private string firstName;
        private string lastName;
        private string defualtSL;

        //Constructors
        public Customer() { }
        public Customer(int customerid, string firstname, string lastname, string defualtsl)
        {
            this.customerID = customerid;
            this.firstName = firstname;
            this.lastName = lastname;
            this.defualtSL = defualtsl;
        }

        //Methods
        public int GetId()
        { return this.customerID; }
        public string GetFName()
        { return this.firstName; }
        public string GetLName()
        { return this.lastName; }
        public string GetDStore()
        { return this.defualtSL; }

        public void SetFName(string firstName)
        { this.firstName = firstName; }
        public void SetLName(string lastName)
        { this.lastName = lastName; }
        public void SetdefualtSL(string defualtSL)
        { this.defualtSL = defualtSL; }

        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($" ID = {this.customerID} /FirstName:{this.firstName} /LastName:{this.lastName} /Defua{this.defualtSL}");
            return sb.ToString();
        }

    }
}