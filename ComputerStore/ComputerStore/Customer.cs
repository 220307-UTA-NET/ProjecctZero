using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore
{
    public class Customer
    {
        public int CustID { get; set; }
        public string CustName { get; set; }
        public string CustLastName { get; set; }


        public Customer() { }
        public Customer(string Name, string LastName)
        {
            this.CustName = Name;
            this.CustLastName = LastName;
           

        }

        override  public string ToString()
        {
            return "CustomerName: " + "'"+ CustName + "'" + " | " + " Customer Last Name: " + "'" + CustLastName + "'";
        }
    }
}
