using Store.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataInfrastructure
{
    public interface IRepository //Provides signatures to be implemented in SQLRepo
    {
        void NewCustomer(string firstName, string lastName, string username, string password, string location);
        IEnumerable<Customer> CustomerSearch(string firstName, string lastName); //Definition for ability to search for Customers in Database

        //IEnumerable<Customer> CustomerLogIn(string username, string password);
        void NewOrder(string fname, string lname);
        void ChangeLocation(string firstName, string lastName);
        void DisplayStoreInventory(string location);
    }
}
